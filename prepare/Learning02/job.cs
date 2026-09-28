/*  Class: Job
Attributes:
*_companyName : string
*_jobTitle : string
*_startYear : int
*_endYear : int

Behaviors:
*Display() : void
*/

public class Job
{
    public string _companyName = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startYear}-{_endYear}");
    }
}