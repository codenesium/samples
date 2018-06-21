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
        [Trait("Table", "Account")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiAccountRequestModelValidatorTest
        {
                public ApiAccountRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AccountType_Create_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountType, null as string);
                }

                [Fact]
                public async void AccountType_Update_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountType, null as string);
                }

                [Fact]
                public async void AccountType_Create_length()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountType, new string('A', 51));
                }

                [Fact]
                public async void AccountType_Update_length()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountType, new string('A', 51));
                }

                [Fact]
                public async void AccountType_Delete()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void EnvironmentIds_Create_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentIds, null as string);
                }

                [Fact]
                public async void EnvironmentIds_Update_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.EnvironmentIds, null as string);
                }

                [Fact]
                public async void JSON_Create_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void JSON_Update_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.JSON, null as string);
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 201));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Account()));

                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(string));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueGetName_Create_Exists()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Account>(new Account()));
                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Create_Not_Exists()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

                        await validator.ValidateCreateAsync(new ApiAccountRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Exists()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Account>(new Account()));
                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueGetName_Update_Not_Exists()
                {
                        Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
                        accountRepository.Setup(x => x.GetName(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
                        var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

                        await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>214f056fee62cc4e483c2a15786ae9ce</Hash>
</Codenesium>*/