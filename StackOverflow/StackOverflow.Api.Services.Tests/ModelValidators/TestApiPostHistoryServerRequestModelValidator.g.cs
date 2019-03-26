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
	[Trait("Table", "PostHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostHistoryServerRequestModelValidatorTest
	{
		public ApiPostHistoryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PostHistoryTypeId_Create_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostHistoryTypeByPostHistoryTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(new PostHistoryType()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostHistoryTypeId, 1);
		}

		[Fact]
		public async void PostHistoryTypeId_Create_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostHistoryTypeByPostHistoryTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostHistoryTypeId, 1);
		}

		[Fact]
		public async void PostHistoryTypeId_Update_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostHistoryTypeByPostHistoryTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(new PostHistoryType()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostHistoryTypeId, 1);
		}

		[Fact]
		public async void PostHistoryTypeId_Update_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostHistoryTypeByPostHistoryTypeId(It.IsAny<int>())).Returns(Task.FromResult<PostHistoryType>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostHistoryTypeId, 1);
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void RevisionGUID_Create_null()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, null as string);
		}

		[Fact]
		public async void RevisionGUID_Update_null()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, null as string);
		}

		[Fact]
		public async void RevisionGUID_Create_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
		}

		[Fact]
		public async void RevisionGUID_Update_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RevisionGUID, new string('A', 37));
		}

		[Fact]
		public async void UserDisplayName_Create_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
		}

		[Fact]
		public async void UserDisplayName_Update_length()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new PostHistory()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserDisplayName, new string('A', 41));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IPostHistoryRepository> postHistoryRepository = new Mock<IPostHistoryRepository>();
			postHistoryRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiPostHistoryServerRequestModelValidator(postHistoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c2efa746e34876cb77075353d9e25149</Hash>
</Codenesium>*/