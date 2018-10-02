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
	public partial class ApiBadgeRequestModelValidatorTest
	{
		public ApiBadgeRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeRequestModelValidator(badgeRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeRequestModelValidator(badgeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeRequestModelValidator(badgeRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBadgeRepository> badgeRepository = new Mock<IBadgeRepository>();
			badgeRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badge()));

			var validator = new ApiBadgeRequestModelValidator(badgeRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgeRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}
	}
}

/*<Codenesium>
    <Hash>fe6f891723543c5b19ae7f55869d00c9</Hash>
</Codenesium>*/