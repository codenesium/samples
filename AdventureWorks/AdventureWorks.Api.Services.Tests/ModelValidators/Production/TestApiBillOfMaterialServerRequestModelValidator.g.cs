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
	public partial class ApiBillOfMaterialServerRequestModelValidatorTest
	{
		public ApiBillOfMaterialServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ComponentID_Create_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByComponentID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
		}

		[Fact]
		public async void ComponentID_Create_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByComponentID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
		}

		[Fact]
		public async void ComponentID_Update_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByComponentID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ComponentID, 1);
		}

		[Fact]
		public async void ComponentID_Update_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByComponentID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ComponentID, 1);
		}

		[Fact]
		public async void ProductAssemblyID_Create_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByProductAssemblyID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductAssemblyID, 1);
		}

		[Fact]
		public async void ProductAssemblyID_Create_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByProductAssemblyID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductAssemblyID, 1);
		}

		[Fact]
		public async void ProductAssemblyID_Update_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByProductAssemblyID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductAssemblyID, 1);
		}

		[Fact]
		public async void ProductAssemblyID_Update_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.ProductByProductAssemblyID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductAssemblyID, 1);
		}

		[Fact]
		public async void UnitMeasureCode_Create_null()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
		}

		[Fact]
		public async void UnitMeasureCode_Update_null()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, null as string);
		}

		[Fact]
		public async void UnitMeasureCode_Create_length()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void UnitMeasureCode_Update_length()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new BillOfMaterial()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, new string('A', 4));
		}

		[Fact]
		public async void UnitMeasureCode_Create_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.UnitMeasureByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitMeasureCode, "A");
		}

		[Fact]
		public async void UnitMeasureCode_Create_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.UnitMeasureByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateCreateAsync(new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, "A");
		}

		[Fact]
		public async void UnitMeasureCode_Update_Valid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.UnitMeasureByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(new UnitMeasure()));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.UnitMeasureCode, "A");
		}

		[Fact]
		public async void UnitMeasureCode_Update_Invalid_Reference()
		{
			Mock<IBillOfMaterialRepository> billOfMaterialRepository = new Mock<IBillOfMaterialRepository>();
			billOfMaterialRepository.Setup(x => x.UnitMeasureByUnitMeasureCode(It.IsAny<string>())).Returns(Task.FromResult<UnitMeasure>(null));

			var validator = new ApiBillOfMaterialServerRequestModelValidator(billOfMaterialRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiBillOfMaterialServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.UnitMeasureCode, "A");
		}
	}
}

/*<Codenesium>
    <Hash>576c64d1904c7c52a7edc73ed362433c</Hash>
</Codenesium>*/