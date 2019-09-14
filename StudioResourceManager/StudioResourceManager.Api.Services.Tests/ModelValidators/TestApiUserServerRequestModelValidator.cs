using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUserServerRequestModelValidatorTest
	{
		public ApiUserServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Password_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, null as string);
		}

		[Fact]
		public async void Password_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
		}

		[Fact]
		public async void Password_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Password, new string('A', 129));
		}

		[Fact]
		public async void Username_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
		}

		[Fact]
		public async void Username_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, null as string);
		}

		[Fact]
		public async void Username_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 129));
		}

		[Fact]
		public async void Username_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Username, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>56b021c418493c26f18b6b6eca9b9d66</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/