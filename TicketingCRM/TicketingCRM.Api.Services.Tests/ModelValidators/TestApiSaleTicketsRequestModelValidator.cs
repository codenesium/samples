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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SaleTickets")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSaleTicketsRequestModelValidatorTest
        {
                public ApiSaleTicketsRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void SaleId_Create_Valid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
                }

                [Fact]
                public async void SaleId_Create_Invalid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
                }

                [Fact]
                public async void SaleId_Update_Valid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleTicketsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
                }

                [Fact]
                public async void SaleId_Update_Invalid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleTicketsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
                }

                [Fact]
                public async void TicketId_Create_Valid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
                }

                [Fact]
                public async void TicketId_Create_Invalid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
                }

                [Fact]
                public async void TicketId_Update_Valid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleTicketsRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
                }

                [Fact]
                public async void TicketId_Update_Invalid_Reference()
                {
                        Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
                        saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

                        var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleTicketsRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>8aece7635b9540dd85c29752d2d2e66f</Hash>
</Codenesium>*/