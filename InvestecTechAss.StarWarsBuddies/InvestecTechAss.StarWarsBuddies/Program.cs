// See https://aka.ms/new-console-template for more information
using System.Net.Http.Json;
using System.Linq;

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

        hasNextPage = !String.IsNullOrWhiteSpace(result.next);
        starwarsUrl = result.next;
        people.AddRange(result.results);

        Console.WriteLine(response);
    }
}
while (hasNextPage);

var buddies = new List<string>();
foreach (var person in people)
{
    var otherPeople = people.Where(x => x.name.ToLower() != person.name.ToLower()).ToList();
    var sameFilmCount = otherPeople.Where(x => x.films.Length == person.films.Length).ToList();
    if (sameFilmCount.Select(x => x.films.Order()).Any(x => x.SequenceEqual(person.films.Order())))
    {
        buddies.Add($"{person.name}");
    }
}
var uniqueNames = buddies.Distinct();

Console.WriteLine(String.Join(',', uniqueNames));

Console.ReadLine();