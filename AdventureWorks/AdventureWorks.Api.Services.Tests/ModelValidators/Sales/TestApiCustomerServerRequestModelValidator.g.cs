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
	[Trait("Table", "Customer")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiCustomerServerRequestModelValidatorTest
	{
		public ApiCustomerServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void AccountNumber_Create_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
		}

		[Fact]
		public async void AccountNumber_Update_null()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
		}

		[Fact]
		public async void AccountNumber_Create_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 11));
		}

		[Fact]
		public async void AccountNumber_Update_length()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 11));
		}

		[Fact]
		public async void StoreID_Create_Valid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.StoreByStoreID(It.IsAny<int>())).Returns(Task.FromResult<Store>(new Store()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StoreID, 1);
		}

		[Fact]
		public async void StoreID_Create_Invalid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.StoreByStoreID(It.IsAny<int>())).Returns(Task.FromResult<Store>(null));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StoreID, 1);
		}

		[Fact]
		public async void StoreID_Update_Valid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.StoreByStoreID(It.IsAny<int>())).Returns(Task.FromResult<Store>(new Store()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.StoreID, 1);
		}

		[Fact]
		public async void StoreID_Update_Invalid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.StoreByStoreID(It.IsAny<int>())).Returns(Task.FromResult<Store>(null));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.StoreID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Valid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Create_Invalid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Valid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		public async void TerritoryID_Update_Invalid_Reference()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.SalesTerritoryByTerritoryID(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Create_Exists()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(new Customer()));
			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Create_Not_Exists()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(null));
			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateCreateAsync(new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Update_Exists()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(new Customer()));
			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
		}

		[Fact]
		private async void BeUniqueByAccountNumber_Update_Not_Exists()
		{
			Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
			customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(null));
			var validator = new ApiCustomerServerRequestModelValidator(customerRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiCustomerServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
		}
	}
}

/*<Codenesium>
    <Hash>4f421658b0a2e65cd2d3b3ef03b2b623</Hash>
</Codenesium>*/