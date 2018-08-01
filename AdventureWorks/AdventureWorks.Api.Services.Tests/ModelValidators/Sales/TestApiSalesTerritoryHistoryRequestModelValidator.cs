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
	[Trait("Table", "SalesTerritoryHistory")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSalesTerritoryHistoryRequestModelValidatorTest
	{
		public ApiSalesTerritoryHistoryRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TerritoryID_Create_Valid_Reference()
		{
			Mock<ISalesTerritoryHistoryRepository> salesTerritoryHistoryRepository = new Mock<ISalesTerritoryHistoryRepository>();
			salesTerritoryHistoryRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesTerritoryHistoryRequestModelValidator(salesTerritoryHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesTerritoryHistoryRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Invalid_Reference()
		{
			Mock<ISalesTerritoryHistoryRepository> salesTerritoryHistoryRepository = new Mock<ISalesTerritoryHistoryRepository>();
			salesTerritoryHistoryRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesTerritoryHistoryRequestModelValidator(salesTerritoryHistoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesTerritoryHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Valid_Reference()
		{
			Mock<ISalesTerritoryHistoryRepository> salesTerritoryHistoryRepository = new Mock<ISalesTerritoryHistoryRepository>();
			salesTerritoryHistoryRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesTerritoryHistoryRequestModelValidator(salesTerritoryHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryHistoryRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Invalid_Reference()
		{
			Mock<ISalesTerritoryHistoryRepository> salesTerritoryHistoryRepository = new Mock<ISalesTerritoryHistoryRepository>();
			salesTerritoryHistoryRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesTerritoryHistoryRequestModelValidator(salesTerritoryHistoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesTerritoryHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}
	}
}

/*<Codenesium>
    <Hash>93c971cb88d925fe524e29764653b451</Hash>
</Codenesium>*/