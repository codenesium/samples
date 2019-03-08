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
	[Trait("Table", "Badges")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBadgesServerRequestModelValidatorTest
	{
		public ApiBadgesServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}

		[Fact]
		public async void UserId_Create_Valid_Reference()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Create_Invalid_Reference()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);

			await validator.ValidateCreateAsync(new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Valid_Reference()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(new Users()));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgesServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UserId, 1);
		}

		[Fact]
		public async void UserId_Update_Invalid_Reference()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.UsersByUserId(It.IsAny<int>())).Returns(Task.FromResult<Users>(null));

			var validator = new ApiBadgesServerRequestModelValidator(badgesRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBadgesServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UserId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>3636bab8e9a9434256e5739c76ee2cc1</Hash>
</Codenesium>*/