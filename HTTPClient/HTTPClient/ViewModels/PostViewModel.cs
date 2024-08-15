using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using HTTPClient.Models;
using HTTPClient.Services;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace HTTPClient.ViewModels
{
   public partial class PostViewModel:ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts; //substituir listas em observal collection
        PostService postsService;
        public ICommand getPostagensCommand {get;}//nao tem set

        public PostViewModel()
        {
            getPostagensCommand = new Command(getPostagens);
            PostService postsService = new PostService();//instanciando o post service

        }




        public async void getPostagens()
        {
             
            Posts = await postsService.GetPostsAsync();// chamando o metodo do service
        }
    }
}
