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
	[Trait("Table", "UnitMeasure")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiUnitMeasureServerRequestModelValidatorTest
	{
		public ApiUnitMeasureServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);
			await validator.ValidateCreateAsync(new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.Get(It.IsAny<string>())).Returns(Task.FromResult(new UnitMeasure()));

			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);
			await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByName_Create_Exists()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));
			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);

			await validator.ValidateCreateAsync(new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Create_Not_Exists()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);

			await validator.ValidateCreateAsync(new ApiUnitMeasureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Exists()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));
			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
		}

		[Fact]
		private async void BeUniqueByName_Update_Not_Exists()
		{
			Mock<IUnitMeasureRepository> unitMeasureRepository = new Mock<IUnitMeasureRepository>();
			unitMeasureRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));
			var validator = new ApiUnitMeasureServerRequestModelValidator(unitMeasureRepository.Object);

			await validator.ValidateUpdateAsync(default(string), new ApiUnitMeasureServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
		}
	}
}

/*<Codenesium>
    <Hash>710dd2d6c48bf46efa81b3734c5f236b</Hash>
</Codenesium>*/