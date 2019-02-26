using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SecureVideoCRMNS.Api.Services.Tests
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
		public async void Email_Create_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Update_null()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, null as string);
		}

		[Fact]
		public async void Email_Create_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
		}

		[Fact]
		public async void Email_Update_length()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new User()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Email, new string('A', 129));
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
		public async void SubscriptionId_Create_Valid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.SubscriptionBySubscriptionId(It.IsAny<int>())).Returns(Task.FromResult<Subscription>(new Subscription()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SubscriptionId, 1);
		}

		[Fact]
		public async void SubscriptionId_Create_Invalid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.SubscriptionBySubscriptionId(It.IsAny<int>())).Returns(Task.FromResult<Subscription>(null));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);

			await validator.ValidateCreateAsync(new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SubscriptionId, 1);
		}

		[Fact]
		public async void SubscriptionId_Update_Valid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.SubscriptionBySubscriptionId(It.IsAny<int>())).Returns(Task.FromResult<Subscription>(new Subscription()));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SubscriptionId, 1);
		}

		[Fact]
		public async void SubscriptionId_Update_Invalid_Reference()
		{
			Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
			userRepository.Setup(x => x.SubscriptionBySubscriptionId(It.IsAny<int>())).Returns(Task.FromResult<Subscription>(null));

			var validator = new ApiUserServerRequestModelValidator(userRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiUserServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SubscriptionId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>9733e34e512b077a1ae71e1f189566e6</Hash>
</Codenesium>*/