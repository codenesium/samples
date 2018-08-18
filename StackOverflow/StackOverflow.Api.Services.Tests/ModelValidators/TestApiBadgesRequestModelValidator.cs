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
	public partial class ApiBadgesRequestModelValidatorTest
	{
		public ApiBadgesRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
			await validator.ValidateCreateAsync(new ApiBadgesRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IBadgesRepository> badgesRepository = new Mock<IBadgesRepository>();
			badgesRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Badges()));

			var validator = new ApiBadgesRequestModelValidator(badgesRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBadgesRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 41));
		}
	}
}

/*<Codenesium>
    <Hash>31179c2ae94fc0a89d6bf77188031c4d</Hash>
</Codenesium>*/