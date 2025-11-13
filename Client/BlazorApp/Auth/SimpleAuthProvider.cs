using System.Security.Claims;
using System.Text.Json;
using ApiContracts.UserFolder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace BlazorApp.Auth;

public class SimpleAuthProvider : AuthenticationStateProvider
{
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    public SimpleAuthProvider(HttpClient httpClient, IJSRuntime jsRuntime)
    {
        this.httpClient = httpClient;
        this.jsRuntime = jsRuntime;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        string userAsJson;

        try
        {
            userAsJson = await jsRuntime.InvokeAsync<string>("sessionStorage.getItem", "currentUser");
        }
        catch
        {
            return new AuthenticationState(new ClaimsPrincipal());
        }

        if (string.IsNullOrEmpty(userAsJson))
            return new AuthenticationState(new ClaimsPrincipal());

        var user = JsonSerializer.Deserialize<UserDto>(userAsJson)!;

        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("Id", user.Id.ToString())
        };

        var identity = new ClaimsIdentity(claims, "apiauth");

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async Task Login(string username, int password)
    {
        var response = await httpClient.PostAsJsonAsync("auth/login", new LoginRequest(username, password));

        if (!response.IsSuccessStatusCode)
            throw new Exception(await response.Content.ReadAsStringAsync());

        var user = await response.Content.ReadFromJsonAsync<UserDto>();

        string data = JsonSerializer.Serialize(user);

        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", data);

        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task Logout()
    {
        await jsRuntime.InvokeVoidAsync("sessionStorage.setItem", "currentUser", "");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}