using API.Models;
using Client.Services;
using IdentityModel.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Client.Pages
{
    public partial class CoffeeShops
    {
        private List<CoffeeShopModel> shops = new();
        [Inject] private HttpClient HttpClient { get;set; }
        [Inject] private IConfiguration config { get; set; }

        [Inject] private ITokenService TokenService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var tokenResponse = await TokenService.GetToken("CoffeeAPI.read");
            HttpClient.SetBearerToken(tokenResponse.AccessToken);
            var result = await HttpClient.GetAsync(config["apiUrl"] + "/api/CoffeeShop");
            if (result.IsSuccessStatusCode)
            {
                shops = await result.Content.ReadFromJsonAsync<List<CoffeeShopModel>>();


            }
        }


    }
}
