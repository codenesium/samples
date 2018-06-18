using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryHistoryRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Update_Invalid_Reference()
                {
                        Mock<ISalesTerritoryHistoryRepository> salesTerritoryHistoryRepository = new Mock<ISalesTerritoryHistoryRepository>();
                        salesTerritoryHistoryRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

                        var validator = new ApiSalesTerritoryHistoryRequestModelValidator(salesTerritoryHistoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>6890765f64cbdc2a9cc42b69d2ebf34e</Hash>
</Codenesium>*/