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
	public partial class ApiSalesOrderHeaderServerRequestModelValidatorTest
	{
		public ApiSalesOrderHeaderServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AccountNumber_Create_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
		}

		[Fact]
		public async void AccountNumber_Update_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 16));
		}

		[Fact]
		public async void Comment_Create_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 129));
		}

		[Fact]
		public async void Comment_Update_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Comment, new string('A', 129));
		}

		[Fact]
		public async void CreditCardApprovalCode_Create_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardApprovalCode, new string('A', 16));
		}

		[Fact]
		public async void CreditCardApprovalCode_Update_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardApprovalCode, new string('A', 16));
		}

		[Fact]
		public async void CreditCardID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CreditCardByCreditCardID(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CreditCardByCreditCardID(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CreditCardByCreditCardID(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(new CreditCard()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CreditCardID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CreditCardByCreditCardID(It.IsAny<int>())).Returns(Task.FromResult<CreditCard>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CreditCardID, 1);
		}

		[Fact]
		public async void CurrencyRateID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CurrencyRateByCurrencyRateID(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateID, 1);
		}

		[Fact]
		public async void CurrencyRateID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CurrencyRateByCurrencyRateID(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateID, 1);
		}

		[Fact]
		public async void CurrencyRateID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CurrencyRateByCurrencyRateID(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(new CurrencyRate()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyRateID, 1);
		}

		[Fact]
		public async void CurrencyRateID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CurrencyRateByCurrencyRateID(It.IsAny<int>())).Returns(Task.FromResult<CurrencyRate>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CurrencyRateID, 1);
		}

		[Fact]
		public async void CustomerID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CustomerByCustomerID(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CustomerID, 1);
		}

		[Fact]
		public async void CustomerID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CustomerByCustomerID(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CustomerID, 1);
		}

		[Fact]
		public async void CustomerID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CustomerByCustomerID(It.IsAny<int>())).Returns(Task.FromResult<Customer>(new Customer()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.CustomerID, 1);
		}

		[Fact]
		public async void CustomerID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.CustomerByCustomerID(It.IsAny<int>())).Returns(Task.FromResult<Customer>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.CustomerID, 1);
		}

		[Fact]
		public async void PurchaseOrderNumber_Create_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PurchaseOrderNumber, new string('A', 26));
		}

		[Fact]
		public async void PurchaseOrderNumber_Update_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PurchaseOrderNumber, new string('A', 26));
		}

		[Fact]
		public async void SalesOrderNumber_Create_null()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, null as string);
		}

		[Fact]
		public async void SalesOrderNumber_Update_null()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, null as string);
		}

		[Fact]
		public async void SalesOrderNumber_Create_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, new string('A', 26));
		}

		[Fact]
		public async void SalesOrderNumber_Update_length()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderHeader()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesOrderNumber, new string('A', 26));
		}

		[Fact]
		public async void SalesPersonID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(new SalesPerson()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void SalesPersonID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesPersonBySalesPersonID(It.IsAny<int>())).Returns(Task.FromResult<SalesPerson>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SalesPersonID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Valid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Invalid_Reference()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Exists()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesOrderHeader>(new SalesOrderHeader()));
			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Create_Not_Exists()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesOrderHeader>(null));
			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateCreateAsync(new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Exists()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesOrderHeader>(new SalesOrderHeader()));
			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		private async void BeUniqueByRowguid_Update_Not_Exists()
		{
			Mock<ISalesOrderHeaderRepository> salesOrderHeaderRepository = new Mock<ISalesOrderHeaderRepository>();
			salesOrderHeaderRepository.Setup(x => x.ByRowguid(It.IsAny<Guid>())).Returns(Task.FromResult<SalesOrderHeader>(null));
			var validator = new ApiSalesOrderHeaderServerRequestModelValidator(salesOrderHeaderRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderHeaderServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.Rowguid, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>79694160d245572787228f3d30a3a467</Hash>
</Codenesium>*/