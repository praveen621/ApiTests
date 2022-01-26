using System;
using RestSharp;
using Newtonsoft.Json;
namespace ApiTests
{
 public class ApiHelper<T>
    {
        public RestClient restClient { get; set; }
        public RestRequest restRequest { get; set; }
        public string BaseUrl = "https://reqres.in/";
        public RestClient SetEndpointUrl(string endpoint)
        {
            //var fullUrl = Path.Combine(BaseUrl, endpoint);
            var restClient = new RestClient(BaseUrl+endpoint);
            return restClient;
        }

        public RestRequest CreateGetRequest()
        {
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public RestRequest CreatePostRequest(string payload)
        {
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreatePutRequest(string payload)
        {
            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest CreateDeleteRequest(string payload)
        {
            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", payload, ParameterType.RequestBody);
            return restRequest;
        }

        public IRestResponse ExecuteRequest(RestRequest request)
        {
            return restClient.Execute(request);
        }

        public Resp GetResponse<Resp>(IRestResponse response)
        {
            var content = response.Content;
            var resp = JsonConvert.DeserializeObject<Resp>(content);
            return resp;
        }

        public static string SerializeObject(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            return json;
        }
  }
}