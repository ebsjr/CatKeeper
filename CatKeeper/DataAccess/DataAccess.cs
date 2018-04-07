namespace Cats
{
    using System.Collections.Generic;
    using Model;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    public class DataAccess
    {
      
        const string _url = "http://agl-developer-test.azurewebsites.net/people.json";
        private readonly HttpClient _httpClient;

        public DataAccess()
        {

            // consume data using HttpClient
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public  IList<Owner>  GetOwners()
        {

            // get reponse message from he url source
            HttpResponseMessage response = _httpClient.GetAsync(_url).Result;

            // read json to string
            string people = response.Content.ReadAsStringAsync().Result;
           
            // Deserialise and load to list of owners object
            var owners = JsonConvert.DeserializeObject<IList<Owner>>(people);

            return owners;
        }

    }
}
