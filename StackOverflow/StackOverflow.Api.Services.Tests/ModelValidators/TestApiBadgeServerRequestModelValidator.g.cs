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
	[Trait("Table", "Badge")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBadgeServerRequestModelValidatorTest
	{
		public ApiBadgeServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeServerRequestModelValidator(badgeRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeServerRequestModelValidator(badgeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeServerRequestModelValidator(badgeRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeServerRequestModelValidator(badgeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgeServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}
	}
}

/*<Codenesium>
    <Hash>db9a37c97d5db0cd83575b2c232569d0</Hash>
</Codenesium>*/