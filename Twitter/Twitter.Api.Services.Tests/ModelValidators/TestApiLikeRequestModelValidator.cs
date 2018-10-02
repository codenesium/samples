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
	[Trait("Table", "Like")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLikeRequestModelValidatorTest
	{
		public ApiLikeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LikerUserId_Create_Valid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLikeRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LikerUserId, 1);
		}

		[Fact]
		public async void LikerUserId_Create_Invalid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);

			await validator.ValidateCreateAsync(new ApiLikeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LikerUserId, 1);
		}

		[Fact]
		public async void LikerUserId_Update_Valid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLikeRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LikerUserId, 1);
		}

		[Fact]
		public async void LikerUserId_Update_Invalid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetUser(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLikeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LikerUserId, 1);
		}

		[Fact]
		public async void TweetId_Create_Valid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetTweet(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);
			await validator.ValidateCreateAsync(new ApiLikeRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TweetId, 1);
		}

		[Fact]
		public async void TweetId_Create_Invalid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetTweet(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);

			await validator.ValidateCreateAsync(new ApiLikeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TweetId, 1);
		}

		[Fact]
		public async void TweetId_Update_Valid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetTweet(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(new Tweet()));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiLikeRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TweetId, 1);
		}

		[Fact]
		public async void TweetId_Update_Invalid_Reference()
		{
			Mock<ILikeRepository> likeRepository = new Mock<ILikeRepository>();
			likeRepository.Setup(x => x.GetTweet(It.IsAny<int>())).Returns(Task.FromResult<Tweet>(null));

			var validator = new ApiLikeRequestModelValidator(likeRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiLikeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TweetId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>5322f182dffafc416e65e85afe548d3e</Hash>
</Codenesium>*/