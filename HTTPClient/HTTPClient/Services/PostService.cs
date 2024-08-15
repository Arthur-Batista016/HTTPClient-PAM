using HTTPClient.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace HTTPClient.Services
{
    internal class PostService
    {
        private HttpClient httpClient;
        private ObservableCollection<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions; // configurar/formatar o JSON

        public PostService()
        {
            httpClient = new HttpClient();
            jsonSerializerOptions = new JsonSerializerOptions
            {
                //propriedades dos serializer options
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
        }

        public async Task<ObservableCollection<Post>> GetPostsAsync() // TASK: usado no await
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);//quero saber todos os posts;
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();// tranforma o conteudo em string;
                    posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, jsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }
    }
}
