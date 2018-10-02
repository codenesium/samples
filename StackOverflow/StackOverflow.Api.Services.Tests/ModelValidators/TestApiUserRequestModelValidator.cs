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
	[Trait("Table", "User")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUserRequestModelValidatorTest
	{
		public ApiUserRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void DisplayName_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
		}

		[Fact]
		public async void DisplayName_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, null as string);
		}

		[Fact]
		public async void DisplayName_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
		}

		[Fact]
		public async void DisplayName_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 41));
		}

		[Fact]
		public async void EmailHash_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
		}

		[Fact]
		public async void EmailHash_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailHash, new string('A', 41));
		}

		[Fact]
		public async void Location_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
		}

		[Fact]
		public async void Location_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Location, new string('A', 101));
		}

		[Fact]
		public async void WebsiteUrl_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
		}

		[Fact]
		public async void WebsiteUrl_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WebsiteUrl, new string('A', 201));
		}
	}
}

/*<Codenesium>
    <Hash>740b8e2a97d242da94a58ece4b015b82</Hash>
</Codenesium>*/