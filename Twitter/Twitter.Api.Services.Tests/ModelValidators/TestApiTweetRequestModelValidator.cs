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
	public partial class ApiTweetRequestModelValidatorTest
	{
		public ApiTweetRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tweet()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void LocationId_Create_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetLocation(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Create_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetLocation(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Update_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetLocation(It.IsAny<int>())).Returns(Task.FromResult<Location>(new Location()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void LocationId_Update_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetLocation(It.IsAny<int>())).Returns(Task.FromResult<Location>(null));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LocationId, 1);
		}

		[Fact]
		public async void UserUserId_Create_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Create_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Update_Valid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserUserId, 1);
		}

		[Fact]
		public async void UserUserId_Update_Invalid_Reference()
		{
			Mock<ITweetRepository> tweetRepository = new Mock<ITweetRepository>();
			tweetRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiTweetRequestModelValidator(tweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>e509af9e4b3446ca86d360bd0e619165</Hash>
</Codenesium>*/