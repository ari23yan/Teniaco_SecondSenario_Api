using Microsoft.Extensions.Configuration;
using Teniaco_SecondSenario_Api.Models.Common;
using Teniaco_SecondSenario_Web.Models.ViewModels.Person;
using Teniaco_SecondSenario_Web.WebServices.Person.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Reflection;

namespace Teniaco_SecondSenario_Web.WebServices.Person.Implementations
{
    public class PersonService : IPersonService
    {
        private readonly IConfiguration _configuration;
        private readonly string _apiUrl;

        public PersonService(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetSection("ApiUrl").Value;
        }




        public async Task<long> CreatePerson(CreatePersonViewModel dto)
        {
            var client = new RestClient(_apiUrl);

            var request = new RestRequest("Person/CreatePerson", Method.Post);

            // Set form content type  
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            // Add DTO properties as form parameters
            request.AddParameter("FirstName", dto.Name);
            request.AddParameter("LastName", dto.LastName);
            request.AddParameter("Email", dto.Mobile);
            request.AddParameter("Email", dto.BirthDay);

            var response = await client.ExecuteAsync(request);


            //var client = new RestClient(_apiUrl);
            //var request = new RestRequest("Person/CreatePerson", Method.Post);
            //request.AddHeader("Content-Type", "multipart/form-data");
            //request.AddBody(dto);
            //var response = await client.ExecuteAsync(request);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var Result = JsonSerializer.Deserialize<ApiResponse<long>>(response.Content, options);
            return Result.Data;
        }

        public Task<bool> DeletePerson(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonViewModel> GetPerson(long id)
        {
            var client = new RestClient(_apiUrl);
            var request = new RestRequest("Person/GetPerson", Method.Get);
            request.AddParameter("Id", id);
            var response = await client.ExecuteAsync(request);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var Result = JsonSerializer.Deserialize<ApiResponse<PersonViewModel>>(response.Content, options);
            return Result.Data;
        }

        public async Task<List<PersonViewModel>> GetPersons()
        {
            var client = new RestClient(_apiUrl);
            var request = new RestRequest("Person/GetAllPersons", Method.Get);
            var response = await client.ExecuteAsync(request);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var Result = JsonSerializer.Deserialize<ApiResponse<List<PersonViewModel>>>(response.Content, options);
            return Result.Data;
        }

        public Task<bool> UpdatePerson(long id, UpdatePersonViewModel dto)
        {
            throw new NotImplementedException();
        }
    }
}
