using System;

namespace WaveLib
{
	public delegate void ErrorEventHandle(Exception e,string error);
	/// <summary>
	/// IWaveControl ��ժҪ˵����
	/// </summary>
	public interface IWaveControl : IWaveRecordInfo
	{
		void Stop();
		void Start();		
		event ErrorEventHandle ErrorEvent;
	}
}
