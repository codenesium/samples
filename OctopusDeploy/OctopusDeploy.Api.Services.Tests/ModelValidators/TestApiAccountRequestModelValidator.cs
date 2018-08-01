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
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
			accountRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Account>(new Account()));
			var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

			await validator.ValidateCreateAsync(new ApiAccountRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
			accountRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
			var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

			await validator.ValidateCreateAsync(new ApiAccountRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
			accountRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Account>(new Account()));
			var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IAccountRepository> accountRepository = new Mock<IAccountRepository>();
			accountRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Account>(null));
			var validator = new ApiAccountRequestModelValidator(accountRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiAccountRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>005f904c1d6a7df038afb8dd9490f1ac</Hash>
</Codenesium>*/