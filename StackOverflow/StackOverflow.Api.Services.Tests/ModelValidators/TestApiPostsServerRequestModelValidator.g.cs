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
	public partial class ApiPostsServerRequestModelValidatorTest
	{
		public ApiPostsServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Body_Create_null()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
		}

		[Fact]
		public async void Body_Update_null()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
		}

		[Fact]
		public async void LastEditorDisplayName_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void LastEditorDisplayName_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void LastEditorUserId_Create_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Create_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Update_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Update_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Create_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Create_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Update_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Update_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.UsersByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void ParentId_Create_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostsByParentId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Create_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostsByParentId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Update_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostsByParentId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Update_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostsByParentId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void PostTypeId_Create_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostTypesByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(new PostTypes()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Create_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostTypesByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Update_Valid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostTypesByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(new PostTypes()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Update_Invalid_Reference()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.PostTypesByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostTypes>(null));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void Tag_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tag, new string('A', 151));
		}

		[Fact]
		public async void Tag_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tag, new string('A', 151));
		}

		[Fact]
		public async void Title_Create_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}

		[Fact]
		public async void Title_Update_length()
		{
			Mock<IPostsRepository> postsRepository = new Mock<IPostsRepository>();
			postsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Posts()));

			var validator = new ApiPostsServerRequestModelValidator(postsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}
	}
}

/*<Codenesium>
    <Hash>8d37c7eee1417ca8f12144c26c46f97c</Hash>
</Codenesium>*/