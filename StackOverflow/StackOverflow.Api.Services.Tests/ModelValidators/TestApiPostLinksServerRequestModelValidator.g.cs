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
	[Trait("Table", "PostLinks")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiPostLinksServerRequestModelValidatorTest
	{
		public ApiPostLinksServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void LinkTypeId_Create_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.LinkTypesByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(new LinkTypes()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Create_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.LinkTypesByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Update_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.LinkTypesByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(new LinkTypes()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void LinkTypeId_Update_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.LinkTypesByLinkTypeId(It.IsAny<int>())).Returns(Task.FromResult<LinkTypes>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.LinkTypeId, 1);
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Create_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Create_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateCreateAsync(new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Update_Valid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}

		[Fact]
		public async void RelatedPostId_Update_Invalid_Reference()
		{
			Mock<IPostLinksRepository> postLinksRepository = new Mock<IPostLinksRepository>();
			postLinksRepository.Setup(x => x.PostsByRelatedPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiPostLinksServerRequestModelValidator(postLinksRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiPostLinksServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.RelatedPostId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>58ddbde3131c16aecb14b176abc22331</Hash>
</Codenesium>*/