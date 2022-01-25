using System;
using RestSharp;
using Newtonsoft.Json;
namespace ApiTests
{
    public class ReqResApi<T>
    {
        public T GetRequest(string endpoint, int pageIndex)
        {
          var api = new ApiHelper<T>();
          var url = api.SetEndpointUrl(endpoint);
          var request = api.CreateGetRequest();
          var response = api.ExecuteRequest();
          var paginationDetails = api.GetResponse<T>(response);
          return paginationDetails;
    }

    public T PostRequest(string endpoint, dynamic payload)
    {
      var user = new ApiHelper<T>();
      var url = user.SetEndpointUrl(endpoint);
      var request = user.CreatePostRequest(payload);
      var response = user.ExecuteRequest();
      var resp = user.GetResponse<T>(response);
      return resp;
    }
    }
}