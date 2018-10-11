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
	[Trait("Table", "Message")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiMessageRequestModelValidatorTest
	{
		public ApiMessageRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Message()));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);
			await validator.ValidateCreateAsync(new ApiMessageRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 129));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Message()));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMessageRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 129));
		}

		// table.Columns[i].GetReferenceTable().AppTableName= User
		[Fact]
		public async void SenderUserId_Create_Valid_Reference()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.UserBySenderUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);
			await validator.ValidateCreateAsync(new ApiMessageRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SenderUserId, 1);
		}

		[Fact]
		public async void SenderUserId_Create_Invalid_Reference()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.UserBySenderUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);

			await validator.ValidateCreateAsync(new ApiMessageRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SenderUserId, 1);
		}

		[Fact]
		public async void SenderUserId_Update_Valid_Reference()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.UserBySenderUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiMessageRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SenderUserId, 1);
		}

		[Fact]
		public async void SenderUserId_Update_Invalid_Reference()
		{
			Mock<IMessageRepository> messageRepository = new Mock<IMessageRepository>();
			messageRepository.Setup(x => x.UserBySenderUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiMessageRequestModelValidator(messageRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiMessageRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SenderUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>179312fc3474e7e1105ba7ca25e22645</Hash>
</Codenesium>*/