using System;

namespace WaveLib
{
	/// <summary>
	/// IWaveInfo 的摘要说明。
	/// </summary>
	public interface IWaveRecordInfo
	{
		string RecordTmpFile{get;}
		string SavedFile{get;set;}
        /// <summary>
        /// 录音质量
        /// </summary>
		Quality RecordQuality{get;set;}
		long RecordSize{get;}
		TimeSpan RecordTimeSpan{get;}
		bool IsRecord{get;}
		
	}
}
