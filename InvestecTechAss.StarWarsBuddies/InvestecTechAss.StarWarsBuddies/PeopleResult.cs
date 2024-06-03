public class PeopleResult
{
    public int count { get; set; }
    public string next { get; set; }
    public object previous { get; set; }
    public Person[] results { get; set; }
}