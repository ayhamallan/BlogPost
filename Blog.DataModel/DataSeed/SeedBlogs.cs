using Blog.DataModel.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DataModel.DataSeed
{
    public static class SeedBlogs
    {
        public static List<BlogPost> SeedBlogPosts()
        {
            return new List<BlogPost>()
            {
                new BlogPost()
                {
                    ID = 1,
                    Auther = "Auther1",
                    Body = "Post Body1",
                    CreationDate = DateTime.Now,
                    ImageUrl = "Image1",
                    Subtitle = "Subtitle1",
                    Title = "Title1"
                },
                new BlogPost
                {
                    ID = 2,
                     Auther = "Auther2",
                    Body = "Post Body2",
                    CreationDate = DateTime.Now,
                    ImageUrl = "Image2",
                    Subtitle = "Subtitle2",
                    Title = "Title2"
                },
                new BlogPost
                {
                    ID = 3,
                     Auther = "Auther3",
                    Body = "Post Body3",
                    CreationDate = DateTime.Now,
                    ImageUrl = "Image3",
                    Subtitle = "Subtitle3",
                    Title = "Title3"
                },
                new BlogPost
                {
                    ID = 4,
                     Auther = "Auther4",
                    Body = "Post Body4",
                    CreationDate = DateTime.Now,
                    ImageUrl = "Image4",
                    Subtitle = "Subtitle4",
                    Title = "Title4"
                },

            };

        }
    }
}
