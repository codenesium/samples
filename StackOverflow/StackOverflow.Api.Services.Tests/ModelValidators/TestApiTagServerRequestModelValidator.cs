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
	[Trait("Table", "Tag")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTagServerRequestModelValidatorTest
	{
		public ApiTagServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ExcerptPostId_Create_Valid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Create_Invalid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Update_Valid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Update_Invalid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void TagName_Create_null()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Update_null()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Create_length()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}

		[Fact]
		public async void TagName_Update_length()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tag()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}

		[Fact]
		public async void WikiPostId_Create_Valid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Create_Invalid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Update_Valid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Update_Invalid_Reference()
		{
			Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();
			tagRepository.Setup(x => x.PostByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiTagServerRequestModelValidator(tagRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTagServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WikiPostId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>d7241160fe89be6a75c55470e119a880</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/