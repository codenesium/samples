using FluentAssertions;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVersionInfoServerRequestModelValidatorTest
	{
		public ApiVersionInfoServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
			versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

			var validator = new ApiVersionInfoServerRequestModelValidator(versionInfoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVersionInfoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
			versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

			var validator = new ApiVersionInfoServerRequestModelValidator(versionInfoRepository.Object);
			await validator.ValidateUpdateAsync(default(long), new ApiVersionInfoServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
		}
	}
}

/*<Codenesium>
    <Hash>3852aa5538e4d4554a938433c24037f4</Hash>
</Codenesium>*/