using HTTPClient.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace HTTPClient.Services
{
    internal class PostService
    {
        private HttpClient httpClient;
        private Post post;
        private ObservableCollection<Post> posts;
        private JsonSerializerOptions jsonSerializerOptions; // configurar/formatar o JSON
        Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

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




        //aula dia 22-08-24
        public async Task<Post> SavePostAsync(Post item)//Task do tipo Post,para retornar as infos da classe post,precisa verifcar o que a api retorna no postman//
        {
            try
            {

                string json = JsonSerializer.Serialize<Post>(item, jsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(response.Content);
                }

            }
            catch (Exception e)
            {
                
                    Debug.WriteLine(e.Message);
              
               
            }
            return post;  //criar um atibuto post;
        }
    }
}
