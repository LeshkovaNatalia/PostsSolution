using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfacies.Entities;
using MvcPostComments.ViewModels;

namespace MvcPostComments.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        #region Public methods

        public static PostEntity ToBllPhoto(this PostViewModel postViewModel)
        {
            return new PostEntity()
            {
                Id = postViewModel.Id,
                Text = postViewModel.Text,
                Name = postViewModel.Name,
                CreatedOn = postViewModel.CreatedOn

            };
        }

        public static PostViewModel ToMvcPost(this PostEntity postEntity)
        {
            return new PostViewModel()
            {
                Id = postEntity.Id,
                Name = postEntity.Name,
                Text = postEntity.Text,
                CreatedOn = postEntity.CreatedOn
            };
        }

        #endregion
    }
}