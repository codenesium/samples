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
	[Trait("Table", "SalesTaxRate")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesTaxRateServerRequestModelValidatorTest
	{
		public ApiSalesTaxRateServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTaxRate()));

			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTaxRate>(new SalesTaxRate()));
			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTaxRate>(null));
			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesTaxRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTaxRate>(new SalesTaxRate()));
			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesTaxRateServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<ISalesTaxRateRepository> salesTaxRateRepository = new Mock<ISalesTaxRateRepository>();
			salesTaxRateRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesTaxRate>(null));
			var validator = new ApiSalesTaxRateServerRequestModelValidator(salesTaxRateRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesTaxRateServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>ff18ddfea8e3be1914b4cfb9f57eaedc</Hash>
</Codenesium>*/