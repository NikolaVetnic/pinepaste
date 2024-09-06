using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace PinePaste.Tests.Integration.StepDefinitions;

[Binding]
internal class PasteStepDefinitions(WebApplicationFactory<Program> factory)
{
    private readonly HttpClient _client = factory.CreateClient();
    private HttpResponseMessage? _response;

    [When(@"a POST request is sent to the Paste endpoint")]
    public async Task WhenAPostRequestIsSentToThePasteEndpoint()
    {
        var content = new { content = "abcd" };
        _response = await _client.PostAsJsonAsync("/api/v1/paste", content);
    }

    [Then(@"the response code is (.*) \(Created\)")]
    public void ThenTheResponseCodeIsCreated(int p0)
    {
        _response!.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}