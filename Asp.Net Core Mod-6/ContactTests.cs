using Asp.Net_Core_Mod_2.Data;
using FluentAssertions;
using System;
namespace Asp.Net_Core_Mod_6
{
    public class ContactTests
    {
        [Fact]
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
        [Fact]
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