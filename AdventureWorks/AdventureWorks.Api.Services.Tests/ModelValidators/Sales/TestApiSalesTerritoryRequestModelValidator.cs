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
        [Trait("Table", "SalesTerritory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesTerritoryRequestModelValidatorTest
        {
                public ApiSalesTerritoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CountryRegionCode_Create_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
                }

                [Fact]
                public async void CountryRegionCode_Update_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, null as string);
                }

                [Fact]
                public async void CountryRegionCode_Create_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
                }

                [Fact]
                public async void CountryRegionCode_Update_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CountryRegionCode, new string('A', 4));
                }

                [Fact]
                public async void CountryRegionCode_Delete()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void @Group_Create_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Group, null as string);
                }

                [Fact]
                public async void @Group_Update_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Group, null as string);
                }

                [Fact]
                public async void @Group_Create_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Group, new string('A', 51));
                }

                [Fact]
                public async void @Group_Update_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.@Group, new string('A', 51));
                }

                [Fact]
                public async void @Group_Delete()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 51));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesTerritory()));

                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                private async void BeUniqueByName_Create_Exists()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));
                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Create_Not_Exists()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(null));
                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesTerritoryRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Exists()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));
                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, "A");
                }

                [Fact]
                private async void BeUniqueByName_Update_Not_Exists()
                {
                        Mock<ISalesTerritoryRepository> salesTerritoryRepository = new Mock<ISalesTerritoryRepository>();
                        salesTerritoryRepository.Setup(x => x.ByName(It.IsAny<string>())).Returns(Task.FromResult<SalesTerritory>(null));
                        var validator = new ApiSalesTerritoryRequestModelValidator(salesTerritoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesTerritoryRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.Name, "A");
                }
        }
}

/*<Codenesium>
    <Hash>f40d80cee416c01aa61cdabe67c11101</Hash>
</Codenesium>*/