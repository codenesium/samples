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
        [Trait("Table", "SalesOrderHeaderSalesReason")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSalesOrderHeaderSalesReasonRequestModelValidatorTest
        {
                public ApiSalesOrderHeaderSalesReasonRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void SalesReasonID_Create_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
                        salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(new SalesReason()));

                        var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderSalesReasonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesReasonID, 1);
                }

                [Fact]
                public async void SalesReasonID_Create_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
                        salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));

                        var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSalesOrderHeaderSalesReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesReasonID, 1);
                }

                [Fact]
                public async void SalesReasonID_Update_Valid_Reference()
                {
                        Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
                        salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(new SalesReason()));

                        var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesOrderHeaderSalesReasonRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SalesReasonID, 1);
                }

                [Fact]
                public async void SalesReasonID_Update_Invalid_Reference()
                {
                        Mock<ISalesOrderHeaderSalesReasonRepository> salesOrderHeaderSalesReasonRepository = new Mock<ISalesOrderHeaderSalesReasonRepository>();
                        salesOrderHeaderSalesReasonRepository.Setup(x => x.GetSalesReason(It.IsAny<int>())).Returns(Task.FromResult<SalesReason>(null));

                        var validator = new ApiSalesOrderHeaderSalesReasonRequestModelValidator(salesOrderHeaderSalesReasonRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSalesOrderHeaderSalesReasonRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SalesReasonID, 1);
                }
        }
}

/*<Codenesium>
    <Hash>0e812a961967c4b5f4d5c04d1b92cbb4</Hash>
</Codenesium>*/