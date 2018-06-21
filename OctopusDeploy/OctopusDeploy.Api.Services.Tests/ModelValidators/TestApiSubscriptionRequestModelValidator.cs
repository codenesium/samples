using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Subscription")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSubscriptionRequestModelValidatorTest
        {
                public ApiSubscriptionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Type_Create_length()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Update_length()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Type, new string('A', 51));
                }

                [Fact]
                public async void Type_Delete()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Subscription()));

                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(new Subscription()));
                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(null));
                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSubscriptionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(new Subscription()));
                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<ISubscriptionRepository> subscriptionRepository = new Mock<ISubscriptionRepository>();
                        subscriptionRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Subscription>(null));
                        var validator = new ApiSubscriptionRequestModelValidator(subscriptionRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiSubscriptionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>0fa1f1a568c8c61eaf78c3159bf331b3</Hash>
</Codenesium>*/