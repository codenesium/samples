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
	[Trait("Table", "PostLink")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostLinkServerRequestModelValidatorTest
	{
		public ApiPostLinkServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LinkTypeId_Create_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.LinkTypeByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(new LinkType()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Create_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.LinkTypeByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Update_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.LinkTypeByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(new LinkType()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Update_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.LinkTypeByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkType>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Create_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Create_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Update_Valid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Update_Invalid_Reference()
		{
			Mock<IPostLinkRepository> postLinkRepository = new Mock<IPostLinkRepository>();
			postLinkRepository.Setup(x => x.PostByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiPostLinkServerRequestModelValidator(postLinkRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinkServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>eea018a64161276c2d06f988f750cbb6</Hash>
</Codenesium>*/