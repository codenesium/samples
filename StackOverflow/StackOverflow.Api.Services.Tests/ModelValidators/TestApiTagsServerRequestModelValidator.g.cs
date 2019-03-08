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
	[Trait("Table", "Tags")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTagsServerRequestModelValidatorTest
	{
		public ApiTagsServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ExcerptPostId_Create_Valid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Create_Invalid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Update_Valid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void ExcerptPostId_Update_Invalid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByExcerptPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ExcerptPostId, 1);
		}

		[Fact]
		public async void TagName_Create_null()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Update_null()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, null as string);
		}

		[Fact]
		public async void TagName_Create_length()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}

		[Fact]
		public async void TagName_Update_length()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Tags()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TagName, new string('A', 151));
		}

		[Fact]
		public async void WikiPostId_Create_Valid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Create_Invalid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);

			await validator.ValidateCreateAsync(new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Update_Valid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.WikiPostId, 1);
		}

		[Fact]
		public async void WikiPostId_Update_Invalid_Reference()
		{
			Mock<ITagsRepository> tagsRepository = new Mock<ITagsRepository>();
			tagsRepository.Setup(x => x.PostsByWikiPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiTagsServerRequestModelValidator(tagsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTagsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.WikiPostId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>69f58c31373331c7e7a501f786e13ef1</Hash>
</Codenesium>*/