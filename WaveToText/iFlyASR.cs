namespace iFly
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;

    public class iFlyASR
    {
        private int BUFFER_NUM = 0x5000;
        private string sess_id = "";

        public iFlyASR(string c1, string c2)
        {
            int errorCode = 0;
            errorCode = QISRInit(c1);
            if (errorCode != 0)
            {
                throw new Exception("QISP初始化失败，错误代码" + errorCode);
            }
            string str = c2;
            //识别语音
            this.sess_id = this.Ptr2Str(QISRSessionBegin(string.Empty, str, ref errorCode));
            if (errorCode != 0)
            {
                throw new Exception("QISRSessionBegin失败，错误代码" + errorCode);
            }
        }

        public string Audio2Txt(string inFile, string outFile = null)
        {
            IntPtr ptr2;
            int errorCode = 0;
            string s = "";
            FileStream stream = new FileStream(inFile, FileMode.OpenOrCreate);
            byte[] buffer = new byte[this.BUFFER_NUM];
            IntPtr destination = Marshal.AllocHGlobal(this.BUFFER_NUM);
            int audioStatus = 2;
            int epStatus = -1;
            int recogStatus = -1;
            int rsltStatus = -1;
            while (stream.Position != stream.Length)
            {
                int num2 = stream.Read(buffer, 0, this.BUFFER_NUM);
                Marshal.Copy(buffer, 0, destination, buffer.Length);
                //写入识别的音频
                errorCode = QISRAudioWrite(this.sess_id, destination, (uint) num2, audioStatus, ref epStatus, ref recogStatus);
                if (errorCode != 0)
                {
                    stream.Close();
                    throw new Exception("QISRAudioWrite err,errCode=" + errorCode);
                }
                //获取识别结果
                if (recogStatus == 0)
                {
                    ptr2 = QISRGetResult(this.sess_id, ref rsltStatus, 0, ref errorCode);
                    if (ptr2 != IntPtr.Zero)
                    {
                        s = s + this.Ptr2Str(ptr2);
                    }
                }
                Thread.Sleep(500);
            }
            stream.Close();
            audioStatus = 4;
            //写入本次识别的音频
            errorCode = QISRAudioWrite(this.sess_id, destination, 1, audioStatus, ref epStatus, ref recogStatus);
            if (errorCode != 0)
            {
                throw new Exception("QISRAudioWrite write last audio err,errCode=" + errorCode);
            }
            int num7 = 0;
            do
            {
                ptr2 = QISRGetResult(this.sess_id, ref rsltStatus, 0, ref errorCode);
                if (ptr2 != IntPtr.Zero)
                {
                    s = s + this.Ptr2Str(ptr2);
                }
                if (errorCode != 0)
                {
                    throw new Exception("QISRGetResult err,errCode=" + errorCode);
                }
                Thread.Sleep(200);
            }
            while ((rsltStatus != 5) && (num7++ < 50));
            if (outFile != null)
            {
                new FileStream(outFile, FileMode.OpenOrCreate).Write(Encoding.Default.GetBytes(s), 0, Encoding.Default.GetByteCount(s));
            }
            return s;
        }

        ~iFlyASR()
        {
            int num = 0;
            num = QISRSessionEnd(this.sess_id, string.Empty);
            num = QISRFini();
        }

        private string Ptr2Str(IntPtr p)
        {
            List<byte> list = new List<byte>();
            while (Marshal.ReadByte(p) != 0)
            {
                list.Add(Marshal.ReadByte(p));
                p = new IntPtr(p.ToInt32() + 1);
            }
            byte[] buffer = list.ToArray();
            return Encoding.GetEncoding("gb2312").GetString(list.ToArray());
        }

        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRAudioWrite(string sessionID, IntPtr waveData, uint waveLen, int audioStatus, ref int epStatus, ref int recogStatus);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRFini();
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRGetParam(string sessionID, string paramName, string paramValue, ref uint valueLen);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr QISRGetResult(string sessionID, ref int rsltStatus, int waitTime, ref int errorCode);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRGrammarActivate(string sessionID, string grammar, string type, int weight);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRInit(string configs);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern IntPtr QISRSessionBegin(string grammarList, string _params, ref int errorCode);
        [DllImport("msc.dll", CallingConvention=CallingConvention.StdCall)]
        public static extern int QISRSessionEnd(string sessionID, string hints);

        public enum AudioStatus
        {
            ISR_AUDIO_SAMPLE_CONTINUE = 2,
            ISR_AUDIO_SAMPLE_END_CHUNK = 0x40,
            ISR_AUDIO_SAMPLE_FIRST = 1,
            ISR_AUDIO_SAMPLE_INIT = 0,
            ISR_AUDIO_SAMPLE_LAST = 4,
            ISR_AUDIO_SAMPLE_LOST = 0x10,
            ISR_AUDIO_SAMPLE_NEW_CHUNK = 0x20,
            ISR_AUDIO_SAMPLE_SUPPRESSED = 8,
            ISR_AUDIO_SAMPLE_VALIDBITS = 0x7f
        }

        public enum EpStatus
        {
            ISR_EP_AFTER_SPEECH = 3,
            ISR_EP_ERROR = 5,
            ISR_EP_IN_SPEECH = 1,
            ISR_EP_LOOKING_FOR_SPEECH = 0,
            ISR_EP_MAX_SPEECH = 6,
            ISR_EP_TIMEOUT = 4
        }

        public enum RecogStatus
        {
            ISR_REC_STATUS_SUCCESS,
            ISR_REC_STATUS_NO_MATCH,
            ISR_REC_STATUS_INCOMPLETE,
            ISR_REC_STATUS_NON_SPEECH_DETECTED,
            ISR_REC_STATUS_SPEECH_DETECTED,
            ISR_REC_STATUS_SPEECH_COMPLETE,
            ISR_REC_STATUS_MAX_CPU_TIME,
            ISR_REC_STATUS_MAX_SPEECH,
            ISR_REC_STATUS_STOPPED,
            ISR_REC_STATUS_REJECTED,
            ISR_REC_STATUS_NO_SPEECH_FOUND
        }
    }
}

