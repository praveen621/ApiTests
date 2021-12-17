using System;

namespace ApiTests
{
    public class ApiTests
    {
        public void Test()
        {
            var api = new Api();
            var result = api.Get();
            Console.WriteLine(result);
        }
    }
}