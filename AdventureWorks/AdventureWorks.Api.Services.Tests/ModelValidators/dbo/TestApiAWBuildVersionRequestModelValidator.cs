using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "AWBuildVersion")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiAWBuildVersionRequestModelValidatorTest
	{
		public ApiAWBuildVersionRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Database_Version_Create_null()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateCreateAsync(new ApiAWBuildVersionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
		}

		[Fact]
		public async void Database_Version_Update_null()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAWBuildVersionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
		}

		[Fact]
		public async void Database_Version_Create_length()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateCreateAsync(new ApiAWBuildVersionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
		}

		[Fact]
		public async void Database_Version_Update_length()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAWBuildVersionRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
		}
	}
}

/*<Codenesium>
    <Hash>af1b803ca6e4702e3830cbf8234ca63d</Hash>
</Codenesium>*/