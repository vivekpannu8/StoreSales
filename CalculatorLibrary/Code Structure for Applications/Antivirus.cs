using System;

public class Virus
{
	private string virusName;
	private string virusVersion;
	private string virusCode;
	private string virusDescription;
	private string virusLevel;
	private int virusId;

	public void setVirusDetails(Virus v) { }
	public Virus getVirusDetails() { }
	public string getVirusCode() { }
	public void setVirusCode(string virusCode) { }
}
public class Scan
{
	public void fullSystemScan() { }
	public void customScan() { }
	public void realTimeScan() { }
	public void quickScan() { }
}
public class InfectedFile(){
	private string infectedFileName;
	private string infectedFileType;
	private string infectedFileLocation;
	private string actionTaken;
}
