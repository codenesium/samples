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
	[Trait("Table", "Post")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostServerRequestModelValidatorTest
	{
		public ApiPostServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Body_Create_null()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
		}

		[Fact]
		public async void Body_Update_null()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Body, null as string);
		}

		[Fact]
		public async void LastEditorDisplayName_Create_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void LastEditorDisplayName_Update_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorDisplayName, new string('A', 41));
		}

		[Fact]
		public async void LastEditorUserId_Create_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Create_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Update_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void LastEditorUserId_Update_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByLastEditorUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LastEditorUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Create_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Create_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Update_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void OwnerUserId_Update_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.UserByOwnerUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.OwnerUserId, 1);
		}

		[Fact]
		public async void ParentId_Create_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostByParentId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Create_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostByParentId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Update_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostByParentId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void ParentId_Update_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostByParentId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ParentId, 1);
		}

		[Fact]
		public async void PostTypeId_Create_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostTypeByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostType>(new PostType()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Create_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostTypeByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostType>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Update_Valid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostTypeByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostType>(new PostType()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void PostTypeId_Update_Invalid_Reference()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.PostTypeByPostTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostType>(null));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostTypeId, 1);
		}

		[Fact]
		public async void Tag_Create_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tag, new string('A', 151));
		}

		[Fact]
		public async void Tag_Update_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Tag, new string('A', 151));
		}

		[Fact]
		public async void Title_Create_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}

		[Fact]
		public async void Title_Update_length()
		{
			Mock<IPostRepository> postRepository = new Mock<IPostRepository>();
			postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Post()));

			var validator = new ApiPostServerRequestModelValidator(postRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Title, new string('A', 251));
		}
	}
}

/*<Codenesium>
    <Hash>b98e80f4610d2d9a42a8e75ff3554071</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/