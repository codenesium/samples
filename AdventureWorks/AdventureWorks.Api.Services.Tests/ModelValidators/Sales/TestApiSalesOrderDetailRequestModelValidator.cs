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
        [Trait("Table", "SalesOrderDetail")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesOrderDetailRequestModelValidatorTest
        {
                public ApiSalesOrderDetailRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void CarrierTrackingNumber_Create_length()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderDetail()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CarrierTrackingNumber, new string('A', 26));
                }

                [Fact]
                public async void CarrierTrackingNumber_Update_length()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderDetail()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.CarrierTrackingNumber, new string('A', 26));
                }

                [Fact]
                public async void CarrierTrackingNumber_Delete()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new SalesOrderDetail()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void ProductID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(new SpecialOfferProduct()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
                }

                [Fact]
                public async void ProductID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
                }

                [Fact]
                public async void ProductID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(new SpecialOfferProduct()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
                }

                [Fact]
                public async void ProductID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
                }

                [Fact]
                public async void SpecialOfferID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(new SpecialOfferProduct()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SpecialOfferID, 1);
                }

                [Fact]
                public async void SpecialOfferID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SpecialOfferID, 1);
                }

                [Fact]
                public async void SpecialOfferID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(new SpecialOfferProduct()));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SpecialOfferID, 1);
                }

                [Fact]
                public async void SpecialOfferID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderDetailRepository> salesOrderDetailRepository = new Mock<ISalesOrderDetailRepository>();
                        salesOrderDetailRepository.Setup(x => x.GetSpecialOfferProduct(It.IsAny<int>())).Returns(Task.FromResult<SpecialOfferProduct>(null));

                        var validator = new ApiSalesOrderDetailRequestModelValidator(salesOrderDetailRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiSalesOrderDetailRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SpecialOfferID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>d13171b1d6c7f4a24af617d22d538061</Hash>
</Codenesium>*/