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
	public partial class ApiUsersServerRequestModelValidatorTest
	{
		public ApiUsersServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void DisplayName_Create_null()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateCreateAsync(new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
		}

		[Fact]
		public async void DisplayName_Update_null()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
		}

		[Fact]
		public async void DisplayName_Create_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateCreateAsync(new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
		}

		[Fact]
		public async void DisplayName_Update_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
		}

		[Fact]
		public async void EmailHash_Create_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateCreateAsync(new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
		}

		[Fact]
		public async void EmailHash_Update_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
		}

		[Fact]
		public async void Location_Create_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateCreateAsync(new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
		}

		[Fact]
		public async void Location_Update_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
		}

		[Fact]
		public async void WebsiteUrl_Create_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateCreateAsync(new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
		}

		[Fact]
		public async void WebsiteUrl_Update_length()
		{
			Mock<IUsersRepository> usersRepository = new Mock<IUsersRepository>();
			usersRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Users()));

			var validator = new ApiUsersServerRequestModelValidator(usersRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUsersServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
		}
	}
}

/*<Codenesium>
    <Hash>45ea3aa54a0e815a61517a05e8646ffc</Hash>
</Codenesium>*/