using System.Net.Http.Json;
using System.Text.Json.Serialization;

const string endpoint = "https://catfact.ninja/fact";

try
{
    using var client = new HttpClient();

    // Consome o endpoint e converte o JSON para o objeto CatFact
    var catFact = await client.GetFromJsonAsync<CatFact>(endpoint);

    if (catFact is null)
    {
        Console.WriteLine("A API não retornou dados.");
        return;
    }

    Console.WriteLine("Fato sobre Gatos:");
    Console.WriteLine();
    Console.WriteLine(catFact.Fact);
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"Erro ao acessar a API: {ex.Message}");
}

// Modelo que representa o JSON retornado pela API
public record CatFact(
    [property: JsonPropertyName("fact")] string Fact,
    [property: JsonPropertyName("length")] int Length
);
