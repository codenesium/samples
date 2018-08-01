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
    <Hash>c8ab3d861fce0141b6fa486d37d9c202</Hash>
</Codenesium>*/