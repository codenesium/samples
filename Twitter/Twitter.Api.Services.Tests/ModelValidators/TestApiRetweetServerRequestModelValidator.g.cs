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
	[Trait("Table", "Retweet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiRetweetServerRequestModelValidatorTest
	{
		public ApiRetweetServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void RetwitterUserId_Create_Valid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.UserByRetwitterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiRetweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RetwitterUserId, 1);
		}

		[Fact]
		public async void RetwitterUserId_Create_Invalid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.UserByRetwitterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiRetweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RetwitterUserId, 1);
		}

		[Fact]
		public async void RetwitterUserId_Update_Valid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.UserByRetwitterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRetweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RetwitterUserId, 1);
		}

		[Fact]
		public async void RetwitterUserId_Update_Invalid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.UserByRetwitterUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRetweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RetwitterUserId, 1);
		}

		[Fact]
		public async void TweetTweetId_Create_Valid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.TweetByTweetTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiRetweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TweetTweetId, 1);
		}

		[Fact]
		public async void TweetTweetId_Create_Invalid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.TweetByTweetTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiRetweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TweetTweetId, 1);
		}

		[Fact]
		public async void TweetTweetId_Update_Valid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.TweetByTweetTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiRetweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TweetTweetId, 1);
		}

		[Fact]
		public async void TweetTweetId_Update_Invalid_Reference()
		{
			Mock<IRetweetRepository> retweetRepository = new Mock<IRetweetRepository>();
			retweetRepository.Setup(x => x.TweetByTweetTweetId(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiRetweetServerRequestModelValidator(retweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiRetweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TweetTweetId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>6af6fe5a50251c5771e9c6dc7f6b62e3</Hash>
</Codenesium>*/