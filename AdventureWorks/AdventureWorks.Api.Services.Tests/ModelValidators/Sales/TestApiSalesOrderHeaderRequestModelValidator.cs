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
        [Trait("Table", "SalesOrderHeader")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesOrderHeaderRequestModelValidatorTest
        {
                public ApiSalesOrderHeaderRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AccountNumber_Create_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
                }

                [Fact]
                public async void AccountNumber_Update_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
                }

                [Fact]
                public async void Comment_Create_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 129));
                }

                [Fact]
                public async void Comment_Update_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 129));
                }

                [Fact]
                public async void CreditCardApprovalCode_Create_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardApprovalCode, new string('A', 16));
                }

                [Fact]
                public async void CreditCardApprovalCode_Update_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardApprovalCode, new string('A', 16));
                }

                [Fact]
                public async void CreditCardID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CreditCardID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCreditCard(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
                }

                [Fact]
                public async void CurrencyRateID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCurrencyRate(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateID, 1);
                }

                [Fact]
                public async void CurrencyRateID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCurrencyRate(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateID, 1);
                }

                [Fact]
                public async void CurrencyRateID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCurrencyRate(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateID, 1);
                }

                [Fact]
                public async void CurrencyRateID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCurrencyRate(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateID, 1);
                }

                [Fact]
                public async void CustomerID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CustomerID, 1);
                }

                [Fact]
                public async void CustomerID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CustomerID, 1);
                }

                [Fact]
                public async void CustomerID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.CustomerID, 1);
                }

                [Fact]
                public async void CustomerID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CustomerID, 1);
                }

                [Fact]
                public async void PurchaseOrderNumber_Create_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PurchaseOrderNumber, new string('A', 26));
                }

                [Fact]
                public async void PurchaseOrderNumber_Update_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PurchaseOrderNumber, new string('A', 26));
                }

                [Fact]
                public async void SalesOrderNumber_Create_null()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, null as string);
                }

                [Fact]
                public async void SalesOrderNumber_Update_null()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, null as string);
                }

                [Fact]
                public async void SalesOrderNumber_Create_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, new string('A', 26));
                }

                [Fact]
                public async void SalesOrderNumber_Update_length()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, new string('A', 26));
                }

                [Fact]
                public async void SalesPersonID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void SalesPersonID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesPerson(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
                }

                [Fact]
                public async void TerritoryID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                private async void BeUniqueBySalesOrderNumber_Create_Exists()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult<SalesOrderHeader>(new SalesOrderHeader()));
                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, "A");
                }

                [Fact]
                private async void BeUniqueBySalesOrderNumber_Create_Not_Exists()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult<SalesOrderHeader>(null));
                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesOrderNumber, "A");
                }

                [Fact]
                private async void BeUniqueBySalesOrderNumber_Update_Exists()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult<SalesOrderHeader>(new SalesOrderHeader()));
                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, "A");
                }

                [Fact]
                private async void BeUniqueBySalesOrderNumber_Update_Not_Exists()
                {
                        Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
                        salesOrderHeaderRepository.Setup(x => x.BySalesOrderNumber(It.IsAny<string>())).Returns(Task.FromResult<SalesOrderHeader>(null));
                        var validator = new ApiSalesOrderHeaderRequestModelValidator(salesOrderHeaderRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesOrderNumber, "A");
                }
        }
}

/*<Codenesium>
    <Hash>3a6af37e3a754895e676b2e9b4c90c59</Hash>
</Codenesium>*/