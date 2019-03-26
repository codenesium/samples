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
	[Trait("Table", "Comment")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCommentServerRequestModelValidatorTest
	{
		public ApiCommentServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);

			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void Text_Create_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Update_null()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Create_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void Text_Update_length()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comment()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);

			await validator.ValidateCreateAsync(new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();
			commentRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiCommentServerRequestModelValidator(commentRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCommentServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>31c1f927a9f825c6e05580045ffb4bb2</Hash>
</Codenesium>*/