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
	[Trait("Table", "QuoteTweet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiQuoteTweetServerRequestModelValidatorTest
	{
		public ApiQuoteTweetServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new QuoteTweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void RetweeterUserId_Create_Valid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.UserByRetweeterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RetweeterUserId, 1);
		}

		[Fact]
		public async void RetweeterUserId_Create_Invalid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.UserByRetweeterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RetweeterUserId, 1);
		}

		[Fact]
		public async void RetweeterUserId_Update_Valid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.UserByRetweeterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RetweeterUserId, 1);
		}

		[Fact]
		public async void RetweeterUserId_Update_Invalid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.UserByRetweeterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RetweeterUserId, 1);
		}

		[Fact]
		public async void SourceTweetId_Create_Valid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.TweetBySourceTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SourceTweetId, 1);
		}

		[Fact]
		public async void SourceTweetId_Create_Invalid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.TweetBySourceTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SourceTweetId, 1);
		}

		[Fact]
		public async void SourceTweetId_Update_Valid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.TweetBySourceTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SourceTweetId, 1);
		}

		[Fact]
		public async void SourceTweetId_Update_Invalid_Reference()
		{
			Mock<IQuoteTweetRepository> quoteTweetRepository = new Mock<IQuoteTweetRepository>();
			quoteTweetRepository.Setup(x => x.TweetBySourceTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiQuoteTweetServerRequestModelValidator(quoteTweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiQuoteTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SourceTweetId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>b3aa2a40de740e629845e80b6073086d</Hash>
</Codenesium>*/