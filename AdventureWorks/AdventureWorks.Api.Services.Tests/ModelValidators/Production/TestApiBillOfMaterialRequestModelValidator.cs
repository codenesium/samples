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
	[Trait("Table", "BillOfMaterial")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiBillOfMaterialRequestModelValidatorTest
	{
		public ApiBillOfMaterialRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void UnitMeasureCode_Create_null()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
		}

		[Fact]
		public async void UnitMeasureCode_Update_null()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
		}

		[Fact]
		public async void UnitMeasureCode_Create_length()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void UnitMeasureCode_Update_length()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
		}
	}
}

/*<Codenesium>
    <Hash>98445e626b3bf9d6040e7af728d27d67</Hash>
</Codenesium>*/