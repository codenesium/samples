using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
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
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VersionInfo")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiVersionInfoRequestModelValidatorTest
	{
		public ApiVersionInfoRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Description_Create_length()
		{
			Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
			versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

			var validator = new ApiVersionInfoRequestModelValidator(versionInfoRepository.Object);
			await validator.ValidateCreateAsync(new ApiVersionInfoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
		}

		[Fact]
		public async void Description_Update_length()
		{
			Mock<IVersionInfoRepository> versionInfoRepository = new Mock<IVersionInfoRepository>();
			versionInfoRepository.Setup(x => x.Get(It.IsAny<long>())).Returns(Task.FromResult(new VersionInfo()));

			var validator = new ApiVersionInfoRequestModelValidator(versionInfoRepository.Object);
			await validator.ValidateUpdateAsync(default(long), new ApiVersionInfoRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Description, new string('A', 1025));
		}
	}
}

/*<Codenesium>
    <Hash>3e0a64534409fba4caf7cee2206dc798</Hash>
</Codenesium>*/