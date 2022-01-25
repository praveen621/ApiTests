using System;
using RestSharp;
using Newtonsoft.Json;

namespace ApiTests  
{
    public class ApiHelper<T>
    {
        public RestClient RestClient { get; set; }
        public RestRequest RestRequest { get; set; }
        public string BaseUrl = "https://reqres.in/";
        public RestClient SetEndpointUrl(string endpoint)
        {
            RestClient = new RestClient(BaseUrl + endpoint);
            return RestClient;
        }

        public RestRequest CreateGetRequest()
        {
            RestRequest = new RestRequest(Method.GET);
            RestRequest.AddHeader("Content-Type", "application/json");
            return RestRequest;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            RestRequest = new RestRequest(Method.POST);
            RestRequest.AddHeader("Content-Type", "application/json");
            RestRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return RestRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            RestRequest = new RestRequest(Method.PUT);
            RestRequest.AddHeader("Content-Type", "application/json");
            RestRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return RestRequest;
        }

        public RestRequest CreateDeleteRequest(string payload)
        {
            RestRequest = new RestRequest(Method.DELETE);
            RestRequest.AddHeader("Content-Type", "application/json");
            RestRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return RestRequest;
        }

        public IRestResponse ExecuteRequest()
        {
            var response = RestClient.Execute(RestRequest);
            return response;
        }

        public Resp GetResponse<Resp>(IRestResponse response)
        {
            var content = response.Content; // raw content as string
            var resp = JsonConvert.DeserializeObject<Resp>(content);
            return resp;
        }
    }
}