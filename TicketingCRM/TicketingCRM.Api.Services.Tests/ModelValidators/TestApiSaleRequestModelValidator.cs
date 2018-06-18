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
        [Trait("Table", "Sale")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiSaleRequestModelValidatorTest
        {
                public ApiSaleRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void IpAddress_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
                }

                [Fact]
                public async void IpAddress_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
                }

                [Fact]
                public async void IpAddress_Create_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
                }

                [Fact]
                public async void IpAddress_Update_length()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
                }

                [Fact]
                public async void IpAddress_Delete()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void Notes_Create_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
                }

                [Fact]
                public async void Notes_Update_null()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
                }

                [Fact]
                public async void TransactionId_Create_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
                }

                [Fact]
                public async void TransactionId_Create_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateCreateAsync(new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
                }

                [Fact]
                public async void TransactionId_Update_Valid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
                }

                [Fact]
                public async void TransactionId_Update_Invalid_Reference()
                {
                        Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
                        saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

                        var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiSaleRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>b96faced87428d82decdd51ef0daceab</Hash>
</Codenesium>*/