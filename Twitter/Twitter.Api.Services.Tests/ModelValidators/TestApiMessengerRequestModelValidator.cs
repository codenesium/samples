using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMessengerRequestModelValidatorTest
	{
		public ApiMessengerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void MessageId_Create_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetMessage(It.IsAny<int>())).Returns(Task.FromResult<Message>(new Message()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MessageId, 1);
		}

		[Fact]
		public async void MessageId_Create_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetMessage(It.IsAny<int>())).Returns(Task.FromResult<Message>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MessageId, 1);
		}

		[Fact]
		public async void MessageId_Update_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetMessage(It.IsAny<int>())).Returns(Task.FromResult<Message>(new Message()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.MessageId, 1);
		}

		[Fact]
		public async void MessageId_Update_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetMessage(It.IsAny<int>())).Returns(Task.FromResult<Message>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.MessageId, 1);
		}

		[Fact]
		public async void ToUserId_Create_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ToUserId, 1);
		}

		[Fact]
		public async void ToUserId_Create_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToUserId, 1);
		}

		[Fact]
		public async void ToUserId_Update_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ToUserId, 1);
		}

		[Fact]
		public async void ToUserId_Update_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ToUserId, 1);
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateCreateAsync(new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IMessengerRepository> messengerRepository = new Mock<IMessengerRepository>();
			messengerRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessengerRequestModelValidator(messengerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMessengerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>a5dfa9f409786d83212f707efc736845</Hash>
</Codenesium>*/