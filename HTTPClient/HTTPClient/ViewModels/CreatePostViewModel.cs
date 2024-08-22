using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

using System.Windows.Input;
using HTTPClient.Services;

namespace HTTPClient.ViewModels
{
    partial class CreatePostViewModel:ObservableObject
    {
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string body;
        [ObservableProperty]
        int id;
        [ObservableProperty]
        int userId=1;

        public ICommand SavePostCommand { get; }

        public CreatePostViewModel()
        {
            SavePostCommand = new Command(SavePost);
        }

        public async void SavePost()
        {
            //TO DO
            Post post = new Post();
            Post newPost = new Post();
           
            post.Title = title;
            post.body = body;
            post.UserId = UserId;

            PostService postService = new PostService();
            newPost = await postService.SavePostAsync(post);
        }
    }
}
