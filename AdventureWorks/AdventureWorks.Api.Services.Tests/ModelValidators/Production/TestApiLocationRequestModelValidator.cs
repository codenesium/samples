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
	[Trait("Table", "Location")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiLocationRequestModelValidatorTest
	{
		public ApiLocationRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(short), new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.Get(It.IsAny<short>())).Returns(Task.FromResult(new Location()));

			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);
			await validator.ValidateUpdateAsync(default(short), new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(new Location()));
			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);

			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(null));
			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);

			await validator.ValidateCreateAsync(new ApiLocationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(new Location()));
			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);

			await validator.ValidateUpdateAsync(default(short), new ApiLocationRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<ILocationRepository> locationRepository = new Mock<ILocationRepository>();
			locationRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<Location>(null));
			var validator = new ApiLocationRequestModelValidator(locationRepository.Object);

			await validator.ValidateUpdateAsync(default(short), new ApiLocationRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>752a0178863b9903bc0b516b327cae5a</Hash>
</Codenesium>*/