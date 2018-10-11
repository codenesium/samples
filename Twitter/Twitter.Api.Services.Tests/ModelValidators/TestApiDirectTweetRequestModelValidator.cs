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
	public partial class ApiDirectTweetRequestModelValidatorTest
	{
		public ApiDirectTweetRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Content_Create_null()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Update_null()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, null as string);
		}

		[Fact]
		public async void Content_Create_length()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		[Fact]
		public async void Content_Update_length()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new DirectTweet()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Content, new string('A', 141));
		}

		// table.Columns[i].GetReferenceTable().AppTableName= User
		[Fact]
		public async void TaggedUserId_Create_Valid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateCreateAsync(new ApiDirectTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Create_Invalid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);

			await validator.ValidateCreateAsync(new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Update_Valid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}

		[Fact]
		public async void TaggedUserId_Update_Invalid_Reference()
		{
			Mock<IDirectTweetRepository> directTweetRepository = new Mock<IDirectTweetRepository>();
			directTweetRepository.Setup(x => x.UserByTaggedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiDirectTweetRequestModelValidator(directTweetRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiDirectTweetRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TaggedUserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>928147dc7ab9945bbb218c21313d1fff</Hash>
</Codenesium>*/