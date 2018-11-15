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
	[Trait("Table", "Following")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiFollowingServerRequestModelValidatorTest
	{
		public ApiFollowingServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Muted_Create_length()
		{
			Mock<IFollowingRepository> followingRepository = new Mock<IFollowingRepository>();
			followingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Following()));

			var validator = new ApiFollowingServerRequestModelValidator(followingRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowingServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}

		[Fact]
		public async void Muted_Update_length()
		{
			Mock<IFollowingRepository> followingRepository = new Mock<IFollowingRepository>();
			followingRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Following()));

			var validator = new ApiFollowingServerRequestModelValidator(followingRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiFollowingServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>6acdfed601096205e33f60f487fbb51f</Hash>
</Codenesium>*/