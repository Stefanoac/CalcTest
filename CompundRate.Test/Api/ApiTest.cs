using System.Net;
using RestSharp;
using Xunit;

namespace CalcTest.Test.Api
{
    public class ApiTest
    {
        private const string Endpoint = "http://localhost:44351";
        private const double Rate = 0.01;

        [Fact]
        public void Value_Ok()
        {
            var client = new RestClient(Endpoint);
            var request = new RestRequest("calculajuros", Method.GET);

            request.AddParameter("valorinicial", 100);
            request.AddParameter("meses", 5);

            // execute the request
            var response = client.Execute(request);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void Value_Is_Zero()
        {
            var client = new RestClient(Endpoint);
            var request = new RestRequest("calculajuros", Method.GET);

            request.AddParameter("valorinicial", 0);
            request.AddParameter("meses", 5);

            // execute the request
            var response = client.Execute(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void Value_Is_Negative()
        {
            var client = new RestClient(Endpoint);
            var request = new RestRequest("calculajuros", Method.GET);

            request.AddParameter("valorinicial", -100);
            request.AddParameter("meses", 5);

            // execute the request
            var response = client.Execute(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void Months_Is_Zero()
        {
            var client = new RestClient(Endpoint);
            var request = new RestRequest("calculajuros", Method.GET);

            request.AddParameter("valorinicial", 100);
            request.AddParameter("meses", 0);

            // execute the request
            var response = client.Execute(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public void Months_Is_Negative()
        {
            var client = new RestClient(Endpoint);
            var request = new RestRequest("calculajuros", Method.GET);

            request.AddParameter("valorinicial", 100);
            request.AddParameter("meses", -5);

            // execute the request
            var response = client.Execute(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
