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
	[Trait("Table", "Votes")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVotesServerRequestModelValidatorTest
	{
		public ApiVotesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(new Posts()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.PostsByPostId(It.IsAny<int>())).Returns(Task.FromResult<Posts>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void VoteTypeId_Create_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.VoteTypesByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(new VoteTypes()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Create_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.VoteTypesByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateCreateAsync(new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Update_Valid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.VoteTypesByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(new VoteTypes()));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Update_Invalid_Reference()
		{
			Mock<IVotesRepository> votesRepository = new Mock<IVotesRepository>();
			votesRepository.Setup(x => x.VoteTypesByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteTypes>(null));

			var validator = new ApiVotesServerRequestModelValidator(votesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVotesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>07aef8a6c34c1f861af63ef618011063</Hash>
</Codenesium>*/