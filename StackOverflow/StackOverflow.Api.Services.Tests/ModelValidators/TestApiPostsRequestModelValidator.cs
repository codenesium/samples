using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Posts")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostsRequestModelValidatorTest
	{
		public ApiPostsRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LastEditorDisplayName_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void LastEditorDisplayName_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void Tags_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tags, new string('A', 151));
		}

		[Fact]
		public async void Tags_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tags, new string('A', 151));
		}

		[Fact]
		public async void Title_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}

		[Fact]
		public async void Title_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}
	}
}

/*<Codenesium>
    <Hash>2fe3f93d45bdb28906c52c339e3c7cbc</Hash>
</Codenesium>*/