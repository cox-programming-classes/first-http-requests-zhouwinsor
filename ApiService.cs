using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace CS_First_HTTP_Client;

public class ApiService
{
    
    private readonly HttpClient _client = new()
    {
        BaseAddress = new Uri("https://forms-dev.winsor.edu")
    };

    private AuthResponse _auth { get; set; }
    //private intialization
    private ApiService () { }
    
    //singleton api service declaration 
    public static readonly ApiService Current = new();
    
    //need to call this method before using any endpoints?
    public async Task<bool> AuthenticateAsync(Login login)
    {
        //start a request
        HttpRequestMessage request = new(HttpMethod.Post, "api/auth");
        //login --> JSON
        string jsonContent = JsonSerializer.Serialize(login);
        //json to body of the request. have to indicate content type
        request.Content = new StringContent(jsonContent,
            Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);
        //get text from response body
        var responseContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            //in case the login went wrong
            Debug.WriteLine(responseContent);
            return false;
        }

        _auth = JsonSerializer.Deserialize<AuthResponse>(responseContent);
        return true;
    }


    public async Task<TOut?> SendAsync<TOut>(HttpMethod method, string endpoint, bool authorize = true)
    {
        HttpRequestMessage request = new(method, endpoint);
    
        if (authorize)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _auth.jwt);
        }

        var response = await _client.SendAsync(request);

        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return JsonSerializer
                .Deserialize<TOut>(responseContent);

        Debug.WriteLine(responseContent);
        return default;
    }

    public async Task<bool> SendAsync(HttpMethod method, string endpoint, bool authorize)
    {
        HttpRequestMessage request = new(method, endpoint);
        
        if (authorize)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _auth.jwt);
        }

        var response = await _client.SendAsync(request);
        if (response.IsSuccessStatusCode)
            return true;
        var responseContent = await response.Content.ReadAsStringAsync();
        
        Debug.WriteLine(responseContent);
        return false;
    }

    public async Task<TOut?> SendAsync<TOut, TIn>(HttpMethod method, string endpoint, TIn content,
        bool authorize = true)
    {
        HttpRequestMessage request = new(method, endpoint);
        if (authorize)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _auth.jwt);
        }

        var jsonContent = JsonSerializer.Serialize(content);
        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        
        var response = await _client.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        if (response.IsSuccessStatusCode)
            return JsonSerializer
                .Deserialize<TOut>(responseContent);
        
        Debug.WriteLine(responseContent);
        return default;
    }

    public async Task<bool> SendAsync<TIn>(HttpMethod method, string endpoint, TIn content, bool authorize = true)
    {
        HttpRequestMessage request = new(method, endpoint);
        
        if (authorize)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _auth.jwt);
        }
        
        var jsonContent = JsonSerializer.Serialize(content);
        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        var response = await _client.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
            return true;
        
        Debug.WriteLine(responseContent);
        return false;
    }
}

