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
	[Trait("Table", "Vote")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVoteServerRequestModelValidatorTest
	{
		public ApiVoteServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PostId_Create_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Create_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(new Post()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void PostId_Update_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.PostByPostId(It.IsAny<int>())).Returns(Task.FromResult<Post>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PostId, 1);
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.UserByUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void VoteTypeId_Create_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.VoteTypeByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(new VoteType()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Create_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.VoteTypeByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateCreateAsync(new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Update_Valid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.VoteTypeByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(new VoteType()));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}

		[Fact]
		public async void VoteTypeId_Update_Invalid_Reference()
		{
			Mock<IVoteRepository> voteRepository = new Mock<IVoteRepository>();
			voteRepository.Setup(x => x.VoteTypeByVoteTypeId(It.IsAny<int>())).Returns(Task.FromResult<VoteType>(null));

			var validator = new ApiVoteServerRequestModelValidator(voteRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiVoteServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.VoteTypeId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>92476479d083ad4787f9fec28965ce5c</Hash>
</Codenesium>*/