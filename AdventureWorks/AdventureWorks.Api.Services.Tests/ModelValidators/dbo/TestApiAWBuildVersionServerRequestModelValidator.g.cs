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
	public partial class ApiAWBuildVersionServerRequestModelValidatorTest
	{
		public ApiAWBuildVersionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Database_Version_Create_null()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionServerRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateCreateAsync(new ApiAWBuildVersionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
		}

		[Fact]
		public async void Database_Version_Update_null()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionServerRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAWBuildVersionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, null as string);
		}

		[Fact]
		public async void Database_Version_Create_length()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionServerRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateCreateAsync(new ApiAWBuildVersionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
		}

		[Fact]
		public async void Database_Version_Update_length()
		{
			Mock<IAWBuildVersionRepository> aWBuildVersionRepository = new Mock<IAWBuildVersionRepository>();
			aWBuildVersionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new AWBuildVersion()));

			var validator = new ApiAWBuildVersionServerRequestModelValidator(aWBuildVersionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiAWBuildVersionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Database_Version, new string('A', 26));
		}
	}
}

/*<Codenesium>
    <Hash>f910cb7eed60112299e69f0dd1328587</Hash>
</Codenesium>*/