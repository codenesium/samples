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
			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.DisplayName, new string('A', 201));
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
			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.EmailAddress, new string('A', 401));
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
			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExternalId, new string('A', 401));
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
			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 201));
		}

		[Fact]
		private async void BeUniqueByUsername_Create_Exists()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.ByUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(new User()));
			var validator = new ApiUserRequestModelValidator(userRepository.Object);

			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, "A");
		}

		[Fact]
		private async void BeUniqueByUsername_Create_Not_Exists()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.ByUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
			var validator = new ApiUserRequestModelValidator(userRepository.Object);

			await validator.ValidateCreateAsync(new ApiUserRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Username, "A");
		}

		[Fact]
		private async void BeUniqueByUsername_Update_Exists()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.ByUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(new User()));
			var validator = new ApiUserRequestModelValidator(userRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, "A");
		}

		[Fact]
		private async void BeUniqueByUsername_Update_Not_Exists()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.ByUsername(It.IsAny<string>())).Returns(Task.FromResult<User>(null));
			var validator = new ApiUserRequestModelValidator(userRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiUserRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Username, "A");
		}
	}
}

/*<Codenesium>
    <Hash>56347c1ad8c6cf7ecf7744e2bb3334b8</Hash>
</Codenesium>*/