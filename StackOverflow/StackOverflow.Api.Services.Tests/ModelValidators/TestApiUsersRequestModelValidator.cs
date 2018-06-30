using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Users")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiUsersRequestModelValidatorTest
        {
                public ApiUsersRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void DisplayName_Create_null()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
                }

                [Fact]
                public async void DisplayName_Update_null()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
                }

                [Fact]
                public async void DisplayName_Create_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
                }

                [Fact]
                public async void DisplayName_Update_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
                }

                [Fact]
                public async void EmailHash_Create_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
                }

                [Fact]
                public async void EmailHash_Update_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
                }

                [Fact]
                public async void Location_Create_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
                }

                [Fact]
                public async void Location_Update_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
                }

                [Fact]
                public async void WebsiteUrl_Create_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateCreateAsync(new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
                }

                [Fact]
                public async void WebsiteUrl_Update_length()
                {
                        Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
                        usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

                        var validator = new ApiUsersRequestModelValidator(usersRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiUsersRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
                }
        }
}

/*<Codenesium>
    <Hash>d0ccf731cb02e7f4593f3f0937b2cd35</Hash>
</Codenesium>*/