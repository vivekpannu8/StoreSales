using System;

public class Virus
{
	private int _virusId;
	private string _virusName;
	private string _virusVersion;
	private string _virusCode;
	private string _virusDescription;
	private string _virusLevel;

	public void setVirusDetails(Virus v) { }
	public Virus getVirusDetails() { }
	public string getVirusCode() { }
	public void setVirusCode(string virusCode) { }
}
public class Scan : Virus
{
	public void fullSystemScan() { }
	public void customScan() { }
	public void realTimeScan() 
	{
		// realTime scan will scan the files in real time when new files are created
		// or copied from other sources to PC or whenever we open any folder it will
		// be auto scanned for possible threats
	}
	public void quickScan() { }
}
public class InfectedFile(){
	private string _infectedFileName { get; set; }
	private string _infectedFileType { get; set; }
	private string _infectedFileLocation { get; set; }
	private string _actionTaken { get; set; }
}
