namespace PostComments.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BLL.Interfacies.Entities;
    using BLL.Interfacies.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using WebApplicationPost.Controllers;

    [TestClass]
    public class PostControllerTests
    {
        [TestMethod]
        public void GetAllPosts_ReturnAllPosts()
        {
            // Arrange
            var testProducts = GetTestPosts();
            var postService = new Mock<IPostService>();
            var commentService = new Mock<ICommentService>();
            var controller = new PostApiController(postService.Object, commentService.Object);

            // Act
            postService.Setup(service => service.GetAllPostEntities()).Returns(testProducts);
            var result = controller.AllPosts();

            // Assert
            Assert.AreEqual(testProducts.Count, result.ToList().Count);
        }

        [TestMethod]
        [DataRow(1)]
        public void GetPostById_ReturnOnePost(int id)
        {
            // Arrange
            var testProducts = GetTestPosts();
            var postService = new Mock<IPostService>();
            var commentService = new Mock<ICommentService>();
            var controller = new PostApiController(postService.Object, commentService.Object);

            // Act
            postService.Setup(service => service.GetPostEntity(id)).Returns(testProducts.Find(p => p.Id == id));
            var result = controller.Get(id);

            // Assert
            Assert.AreEqual(id, result.Id);
        }

        private List<PostEntity> GetTestPosts()
        {
            var testPosts = new List<PostEntity>();
            testPosts.Add(new PostEntity { Id = 1, Name = "FirstPost", Text = "Text of FirstPost" });
            testPosts.Add(new PostEntity { Id = 2, Name = "SecondPost", Text = "Text of SecondPost" });
            testPosts.Add(new PostEntity { Id = 3, Name = "ThirdPost", Text = "Text of ThirdPost" });

            return testPosts;
        }
    }
}
