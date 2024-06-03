// See https://aka.ms/new-console-template for more information
using System.Text.Json.Serialization;

//internal class PeopleResult
//{
//    //[JsonPropertyName("count")]
//    //internal int Count { get; set; }

//    //[JsonPropertyName("next")]
//    //internal string NextUrl { get; set; }

//    //[JsonPropertyName("previous")]
//    //internal string PreviousUrl { get; set; }

//    //[JsonPropertyName("results")]
//    //internal Person[] Results { get; set; }


//}


public class PeopleResult
{
    public string next { get; set; }
    public Person[] results { get; set; }
}

public class Person
{
    public string name { get; set; }
    public string[] films { get; set; }
}
