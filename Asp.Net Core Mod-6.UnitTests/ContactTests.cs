using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Asp.Net_Core_Mod_2.Data;

namespace Asp.Net_Core_Mod_6.UnitTests
{
    [TestClass]
    public class ContactTests
    {
        //[Fact]
        [TestMethod]
        public void InActivate_SetsIsActiveToFalse()
        {
            // Arrange
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "1234567890",
                BirthDate = DateTime.Now,
                IsActive = true,
                InActivatedDate = null
            };

            // Act
            contact.InActivate();

            // Assert
            contact.IsActive.Should().BeFalse();
        }
        [TestMethod]
        public void InActivate_SetsInActivatedDate()
        {
            // Arrange
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                PhoneNumber = "1234567890",
                BirthDate = DateTime.Now,
                IsActive = true,
                InActivatedDate = null
            };

            // Act
            contact.InActivate();

            // Assert
            contact.InActivatedDate.Should().NotBeNull();
        }
    }
   
}
