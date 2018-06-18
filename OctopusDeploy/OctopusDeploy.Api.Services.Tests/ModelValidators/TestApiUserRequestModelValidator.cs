using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "User")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiUserRequestModelValidatorTest
        {
                public ApiUserRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DisplayName_Create_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 201));
                }

                [Fact]
                public async void DisplayName_Update_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 201));
                }

                [Fact]
                public async void DisplayName_Delete()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EmailAddress_Create_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 401));
                }

                [Fact]
                public async void EmailAddress_Update_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 401));
                }

                [Fact]
                public async void EmailAddress_Delete()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ExternalId_Create_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, new string('A', 401));
                }

                [Fact]
                public async void ExternalId_Update_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ExternalId, new string('A', 401));
                }

                [Fact]
                public async void ExternalId_Delete()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Username_Create_null()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Update_null()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
                }

                [Fact]
                public async void Username_Create_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 201));
                }

                [Fact]
                public async void Username_Update_length()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 201));
                }

                [Fact]
                public async void Username_Delete()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new User()));

                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetUsername_Create_Exists()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(new User()));
                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, "A");
                }

                [Fact]
                private async void BeUniqueGetUsername_Create_Not_Exists()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateCreateAsync(new ApiUserRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Username, "A");
                }

                [Fact]
                private async void BeUniqueGetUsername_Update_Exists()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(new User()));
                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Username, "A");
                }

                [Fact]
                private async void BeUniqueGetUsername_Update_Not_Exists()
                {
                        Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
                        userRepository.Setup(x => x.GetUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
                        var validator = new ApiUserRequestModelValidator(userRepository.Object);

                        await validator.ValidateUpdateAsync(default (string), new ApiUserRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Username, "A");
                }
        }
}

/*<Codenesium>
    <Hash>5a2317dccf472eaa062e61f32e2ea612</Hash>
</Codenesium>*/