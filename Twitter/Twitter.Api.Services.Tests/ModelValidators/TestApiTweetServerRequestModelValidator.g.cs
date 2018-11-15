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
	[Trait("Table", "Tweet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTweetServerRequestModelValidatorTest
	{
		public ApiTweetServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void LocationId_Create_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.LocationByLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Create_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.LocationByLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Update_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.LocationByLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Update_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.LocationByLocationId(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void UserUserId_Create_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.UserByUserUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Create_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.UserByUserUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Update_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.UserByUserUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Update_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.UserByUserUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTweetServerRequestModelValidator(tweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>5fb4e0c04af197a8f8b6e3ce90a0d47e</Hash>
</Codenesium>*/