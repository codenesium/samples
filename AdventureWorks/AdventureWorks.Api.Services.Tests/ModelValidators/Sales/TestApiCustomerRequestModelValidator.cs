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
        [Trait("Table", "Customer")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiCustomerRequestModelValidatorTest
        {
                public ApiCustomerRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void AccountNumber_Create_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
                }

                [Fact]
                public async void AccountNumber_Update_null()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, null as string);
                }

                [Fact]
                public async void AccountNumber_Create_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 11));
                }

                [Fact]
                public async void AccountNumber_Update_length()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, new string('A', 11));
                }

                [Fact]
                public async void AccountNumber_Delete()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Customer()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void StoreID_Create_Valid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetStore(It.IsAny<int>())).Returns(Task.FromResult<Store>(new Store()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StoreID, 1);
                }

                [Fact]
                public async void StoreID_Create_Invalid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetStore(It.IsAny<int>())).Returns(Task.FromResult<Store>(null));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StoreID, 1);
                }

                [Fact]
                public async void StoreID_Update_Valid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetStore(It.IsAny<int>())).Returns(Task.FromResult<Store>(new Store()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.StoreID, 1);
                }

                [Fact]
                public async void StoreID_Update_Invalid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetStore(It.IsAny<int>())).Returns(Task.FromResult<Store>(null));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.StoreID, 1);
                }

                [Fact]
                public async void TerritoryID_Create_Valid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Create_Invalid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Update_Valid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(new SalesTerritory()));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                public async void TerritoryID_Update_Invalid_Reference()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.GetSalesTerritory(It.IsAny<int>())).Returns(Task.FromResult<SalesTerritory>(null));

                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TerritoryID, 1);
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Create_Exists()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(new Customer()));
                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Create_Not_Exists()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(null));
                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateCreateAsync(new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Update_Exists()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(new Customer()));
                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.AccountNumber, "A");
                }

                [Fact]
                private async void BeUniqueByAccountNumber_Update_Not_Exists()
                {
                        Mock<ICustomerRepository> customerRepository = new Mock<ICustomerRepository>();
                        customerRepository.Setup(x => x.ByAccountNumber(It.IsAny<string>())).Returns(Task.FromResult<Customer>(null));
                        var validator = new ApiCustomerRequestModelValidator(customerRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiCustomerRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.AccountNumber, "A");
                }
        }
}

/*<Codenesium>
    <Hash>7b32688084da4c10f7f5db36eccbdc57</Hash>
</Codenesium>*/