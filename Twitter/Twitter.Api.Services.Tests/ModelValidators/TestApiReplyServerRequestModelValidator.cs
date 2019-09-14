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
	public partial class ApiReplyServerRequestModelValidatorTest
	{
		public ApiReplyServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Reply()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void ReplierUserId_Create_Valid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.UserByReplierUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateCreateAsync(new ApiReplyServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Create_Invalid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.UserByReplierUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);

			await validator.ValidateCreateAsync(new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Update_Valid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.UserByReplierUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiReplyServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}

		[Fact]
		public async void ReplierUserId_Update_Invalid_Reference()
		{
			Mock<IReplyRepository> replyRepository = new Mock<IReplyRepository>();
			replyRepository.Setup(x => x.UserByReplierUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiReplyServerRequestModelValidator(replyRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiReplyServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ReplierUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>fac2ee6eaee4b7963a0cf535b0f613bc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/