// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;

var starwarsUrl = @"https://swapi.dev/api/people";
var hasNextPage = false;

List<Person> people = new List<Person>();
do
{
    PeopleResult result = new PeopleResult();
    using (var client = new HttpClient())
    {
        var response = await client.GetAsync(starwarsUrl);
        if (response == null)
        {
            throw new ArgumentNullException($"{nameof(response)}");
        }
        var resultString = await response.Content.ReadAsStringAsync();
        result = System.Text.Json.JsonSerializer.Deserialize<PeopleResult>(resultString, new System.Text.Json.JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
            
        });

        hasNextPage = result.next != null;
        people.AddRange(result.results);

        Console.WriteLine(response);
    }
}
while (hasNextPage);

var buddies = string.Empty;
foreach (var person in people)
{
    if (people.Any(x => x.films == person.films))
    {
        buddies += $"{person.name},";
    }
}

Console.WriteLine(buddies);