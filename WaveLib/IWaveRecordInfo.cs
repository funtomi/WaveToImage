using System;

namespace WaveLib
{
	/// <summary>
	/// IWaveInfo ��ժҪ˵����
	/// </summary>
	public interface IWaveRecordInfo
	{
		string RecordTmpFile{get;}
		string SavedFile{get;set;}
        /// <summary>
        /// ¼������
        /// </summary>
		Quality RecordQuality{get;set;}
		long RecordSize{get;}
		TimeSpan RecordTimeSpan{get;}
		bool IsRecord{get;}
		
	}
}
