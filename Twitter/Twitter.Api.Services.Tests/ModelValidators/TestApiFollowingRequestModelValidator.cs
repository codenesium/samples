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
	public partial class ApiFollowingRequestModelValidatorTest
	{
		public ApiFollowingRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Muted_Create_length()
		{
			Mock<IFollowingRepository> followingRepository = new Mock<IFollowingRepository>();
			followingRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Following()));

			var validator = new ApiFollowingRequestModelValidator(followingRepository.Object);
			await validator.ValidateCreateAsync(new ApiFollowingRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}

		[Fact]
		public async void Muted_Update_length()
		{
			Mock<IFollowingRepository> followingRepository = new Mock<IFollowingRepository>();
			followingRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new Following()));

			var validator = new ApiFollowingRequestModelValidator(followingRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiFollowingRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Muted, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>29da02951efb4736f0aadf1b4a22c161</Hash>
</Codenesium>*/