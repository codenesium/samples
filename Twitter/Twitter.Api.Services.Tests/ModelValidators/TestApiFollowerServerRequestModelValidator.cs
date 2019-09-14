using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Follower")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFollowerServerRequestModelValidatorTest
	{
		public ApiFollowerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Blocked_Create_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Blocked, null as string);
		}

		[Fact]
		public async void Blocked_Update_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Blocked, null as string);
		}

		[Fact]
		public async void Blocked_Create_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Blocked, new string('A', 2));
		}

		[Fact]
		public async void Blocked_Update_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Blocked, new string('A', 2));
		}

		[Fact]
		public async void FollowRequestStatu_Create_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowRequestStatu, null as string);
		}

		[Fact]
		public async void FollowRequestStatu_Update_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowRequestStatu, null as string);
		}

		[Fact]
		public async void FollowRequestStatu_Create_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowRequestStatu, new string('A', 2));
		}

		[Fact]
		public async void FollowRequestStatu_Update_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowRequestStatu, new string('A', 2));
		}

		[Fact]
		public async void FollowedUserId_Create_Valid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FollowedUserId, 1);
		}

		[Fact]
		public async void FollowedUserId_Create_Invalid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);

			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowedUserId, 1);
		}

		[Fact]
		public async void FollowedUserId_Update_Valid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FollowedUserId, 1);
		}

		[Fact]
		public async void FollowedUserId_Update_Invalid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowedUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowedUserId, 1);
		}

		[Fact]
		public async void FollowingUserId_Create_Valid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowingUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FollowingUserId, 1);
		}

		[Fact]
		public async void FollowingUserId_Create_Invalid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowingUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);

			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowingUserId, 1);
		}

		[Fact]
		public async void FollowingUserId_Update_Valid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowingUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(new User()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.FollowingUserId, 1);
		}

		[Fact]
		public async void FollowingUserId_Update_Invalid_Reference()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.UserByFollowingUserId(It.IsAny<int>())).Returns(Task.FromResult<User>(null));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.FollowingUserId, 1);
		}

		[Fact]
		public async void Muted_Create_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, null as string);
		}

		[Fact]
		public async void Muted_Update_null()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, null as string);
		}

		[Fact]
		public async void Muted_Create_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}

		[Fact]
		public async void Muted_Update_length()
		{
			Mock<IFollowerRepository> followerRepository = new Mock<IFollowerRepository>();
			followerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Follower()));

			var validator = new ApiFollowerServerRequestModelValidator(followerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>4fc0a0c2c24824697593fdf720212e5c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/