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
	[Trait("Table", "Reply")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiReplyRequestModelValidatorTest
	{
		public ApiReplyRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void ReplierUserId_Create_Valid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Create_Invalid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);

			await validator.ValidateCreateAsync(new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Update_Valid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Update_Invalid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiReplyRequestModelValidator(replyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiReplyRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c92db163d2f2bf5a3562cb97e7e6042c</Hash>
</Codenesium>*/