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
	[Trait("Table", "Comments")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCommentsServerRequestModelValidatorTest
	{
		public ApiCommentsServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);

			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void Text_Create_null()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Update_null()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, null as string);
		}

		[Fact]
		public async void Text_Create_length()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void Text_Update_length()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Comments()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Text, new string('A', 701));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);

			await validator.ValidateCreateAsync(new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<ICommentsRepository> commentsRepository = new Mock<ICommentsRepository>();
			commentsRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiCommentsServerRequestModelValidator(commentsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCommentsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c54fae4b794b58b302041917076b0ece</Hash>
</Codenesium>*/