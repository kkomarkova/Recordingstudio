using System;
using Bunit;
using HQrecordingstudioBlazor.Client.Pages;
using Xunit;

namespace HqrecordingstudioTest
{
    //Verify if the markup for a component follows the same pattern through the MarkupMatches bUnit interface method.
    public class IndexTest
    {
        [Fact]
        public void RendersSuccessfully()
        {
            //Arrange
            using var ctx = new TestContext();

            // Act
            var component = ctx.RenderComponent<HQrecordingstudioBlazor.Client.Pages.Index>();

            // Assert
            Assert.Equal("This Month’s", component.Find($"h1").TextContent);
        }

    }
}



