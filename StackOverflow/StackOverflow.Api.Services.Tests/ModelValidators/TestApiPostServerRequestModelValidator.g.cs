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
    <Hash>54ceb51d0c4a327d6ed3b8f7f922cf8c</Hash>
</Codenesium>*/