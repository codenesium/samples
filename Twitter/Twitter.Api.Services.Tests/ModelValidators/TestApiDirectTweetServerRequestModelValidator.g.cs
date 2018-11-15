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
	[Trait("Table", "DirectTweet")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiDirectTweetServerRequestModelValidatorTest
	{
		public ApiDirectTweetServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void TaggedUserId_Create_Valid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Create_Invalid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Update_Valid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Update_Invalid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiDirectTweetServerRequestModelValidator(directTweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>49e8a99364a009faacd7b3ed81f0fe4e</Hash>
</Codenesium>*/