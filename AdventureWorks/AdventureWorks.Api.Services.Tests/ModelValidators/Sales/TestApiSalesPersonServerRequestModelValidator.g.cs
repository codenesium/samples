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
	[Trait("Table", "SalesPerson")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesPersonServerRequestModelValidatorTest
	{
		public ApiSalesPersonServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TerritoryID_Create_Valid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Invalid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Valid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Invalid_Reference()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));
			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesPerson>(null));
			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));
			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<ISalesPersonRepository> salesPersonRepository = new Mock<ISalesPersonRepository>();
			salesPersonRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesPerson>(null));
			var validator = new ApiSalesPersonServerRequestModelValidator(salesPersonRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesPersonServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>e0452075312f070e9c941a1a1bc9160e</Hash>
</Codenesium>*/