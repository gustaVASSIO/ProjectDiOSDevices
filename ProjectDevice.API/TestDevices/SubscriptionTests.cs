using ProjectDevice.API.Models;
using System.ComponentModel.DataAnnotations;

namespace TestDevices
{
    public class SubscriptionTests
    {
        [Fact(DisplayName = "Given a wrong value for subscriptio, when create a object, should return a validation error")]
        public void GivenInvalideValues_WhenCreateSubscritpin_ThenTrhowValidationException()
        {
            var subscription = CreateInvalidSubscription();
            
            Assert.Throws<ValidationException>(() =>
            Validator.ValidateObject(subscription, new ValidationContext(subscription), validateAllProperties: true)); 

        }
        private Subscription CreateInvalidSubscription()
        {
            Subscription subscription = new Subscription()
            {
                Title = "",
                Description = ""
            };
            return subscription;
        }
    }
}
