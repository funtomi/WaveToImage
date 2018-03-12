using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;

namespace WaveLib {
    /// <summary>
    /// Wave ��ժҪ˵����
    /// </summary>
    public class Wave : IWaveControl {
        private WaveInRecorder m_Recorder;
        private WaveFormat m_Format;


        System.IO.BinaryWriter bw_tmp;
        private string tmpName = "tmp.wav";
        private FileStream fs_tmp;
        private byte[] m_RecBuffer;

        public Wave() {

        }

        private void DataArrived(IntPtr data, int size) {
            try {
                if (m_RecBuffer == null || m_RecBuffer.Length < size) {
                    m_RecBuffer = new byte[size];
                }
                System.Runtime.InteropServices.Marshal.Copy(data, m_RecBuffer, 0, size);

                bw_tmp.Write(m_RecBuffer);
                _recordSize += m_RecBuffer.Length;
            } catch {
                return;
            }
        }

        private void WriteToFile() {
            FileStream fs = null;
            BinaryReader br = null;
            FileStream fs_2 = null;
            BinaryWriter bw = null;
            bool _isFinish = false;

            try {
                fs = new FileStream(tmpName, FileMode.Open);
                br = new BinaryReader(fs);

                fs_2 = new FileStream(SavedFile, FileMode.Create);
                bw = new BinaryWriter(fs_2);

                //wavͷ
                long chunksize = fs.Length + 36;
                WriteChars(bw, "RIFF");//��ʽ
                bw.Write((int)chunksize);//�ļ����ȣ�Ҫ����ͷ��36�ֽڣ�
                WriteChars(bw, "WAVE");//��ʾ
                WriteChars(bw, "fmt ");//fmt
                bw.Write((int)16);//fmt����
                bw.Write(m_Format.wFormatTag);//ѹ��ģʽ
                bw.Write(m_Format.nChannels);//����
                bw.Write(m_Format.nSamplesPerSec);//�����ʰ�����32000Hz,44100Hz,48000Hz.
                bw.Write(m_Format.nAvgBytesPerSec);//ÿ�벥���ֽ�
                bw.Write(m_Format.nBlockAlign);//λ��
                bw.Write(m_Format.wBitsPerSample);//������С
                WriteChars(bw, "data");//data��־
                bw.Write(fs.Length);//��Ƶ����
                bw.Flush();

                byte[] bytes = new byte[512];
                while (true) {
                    if (br.Read(bytes, 0, bytes.Length) > 0) {
                        bw.Write(bytes);
                    } else {
                        break;
                    }
                }

                _isFinish = true;

            } catch (Exception e) {
                OnError(e, "�ļ���д���쳣!");
            } finally {
                if (br != null) br.Close();
                if (bw != null) bw.Close();

                System.Threading.Thread.Sleep(500);

                if (_isFinish) {
                    FileInfo fi = new FileInfo(tmpName);
                    fi.Delete();
                }
            }

        }

        private void WriteChars(BinaryWriter wrtr, string text) {
            for (int i = 0; i < text.Length; i++) {
                char c = (char)text[i];
                wrtr.Write(c);
            }
        }

        public void Stop() {
            if (m_Recorder != null) {
                try {
                    bw_tmp.Close();
                    m_Recorder.Dispose();


                    WriteToFile();

                    _recordSize = 0;
                    _isRecord = false;
                } finally {
                    m_Recorder = null;
                }
            }
        }

        public void Start() {
            if (_isRecord) return;
            Stop();
            try {
                FileInfo file = new FileInfo(tmpName);
                if (file.Exists) {
                    file.Delete();
                }
                fs_tmp = new FileStream(tmpName, System.IO.FileMode.Create);
                bw_tmp = new BinaryWriter(fs_tmp);

                dt_Start = DateTime.Now;
                _isRecord = true;
                m_Format = new WaveFormat(16000, 16, 1);
                //if(RecordQuality==Quality.low) m_Format = new WaveFormat(32000, 8, 2);
                //else if(RecordQuality==Quality.Normal) m_Format = new WaveFormat(44100, 8, 2);
                //else m_Format = new WaveFormat(44100, 16, 2);

                m_Recorder = new WaveInRecorder(-1, m_Format, 16384, 3, new BufferDoneEventHandler(DataArrived));

            } catch (Exception e) {
                OnError(e, "����¼��ʧ��!");
                Stop();
            }
        }



        #region IWaveRecordInfo ��Ա


        /// <summary>
        /// �洢·��
        /// </summary>
        public string SavedFile {
            get {
                return _saveFile;
            }
            set {
                _saveFile = value;
            }
        }
        private string _saveFile = null;

        private Quality _RecordQuality;
        public Quality RecordQuality {
            get {
                return _RecordQuality;
            }
            set {
                _RecordQuality = value;
            }
        }

        public string RecordTmpFile {
            get {
                return tmpName;
            }
        }

        private long _recordSize = 36;
        public long RecordSize {
            get {
                // TODO:  ��� Wave.RecordSize getter ʵ��
                return _recordSize;
            }
        }

        DateTime dt_Start;
        TimeSpan ts_now;
        public TimeSpan RecordTimeSpan {
            get {
                // TODO:  ��� Wave.RecordTimeSpan getter ʵ��
                if (IsRecord)
                    ts_now = DateTime.Now.Subtract(dt_Start);

                return ts_now;
            }
        }

        private bool _isRecord = false;
        public bool IsRecord {
            get {
                // TODO:  ��� Wave.IsRecord getter ʵ��
                return _isRecord;
            }
        }



        #endregion

        #region IWaveControl ��Ա

        public event ErrorEventHandle ErrorEvent;

        private void OnError(Exception e, string error) {
            if (ErrorEvent != null)
                ErrorEvent(e, error);
        }
        #endregion
    }
}
