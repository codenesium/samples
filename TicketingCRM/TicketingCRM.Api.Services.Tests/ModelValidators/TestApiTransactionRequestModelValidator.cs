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
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Transaction")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTransactionRequestModelValidatorTest
        {
                public ApiTransactionRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void GatewayConfirmationNumber_Create_null()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, null as string);
                }

                [Fact]
                public async void GatewayConfirmationNumber_Update_null()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, null as string);
                }

                [Fact]
                public async void GatewayConfirmationNumber_Create_length()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, new string('A', 2));
                }

                [Fact]
                public async void GatewayConfirmationNumber_Update_length()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, new string('A', 2));
                }

                [Fact]
                public async void GatewayConfirmationNumber_Delete()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TransactionStatusId_Create_Valid_Reference()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.GetTransactionStatus(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(new TransactionStatus()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateCreateAsync(new ApiTransactionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TransactionStatusId, 1);
                }

                [Fact]
                public async void TransactionStatusId_Create_Invalid_Reference()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.GetTransactionStatus(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(null));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionStatusId, 1);
                }

                [Fact]
                public async void TransactionStatusId_Update_Valid_Reference()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.GetTransactionStatus(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(new TransactionStatus()));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TransactionStatusId, 1);
                }

                [Fact]
                public async void TransactionStatusId_Update_Invalid_Reference()
                {
                        Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
                        transactionRepository.Setup(x => x.GetTransactionStatus(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatus>(null));

                        var validator = new ApiTransactionRequestModelValidator(transactionRepository.Object);

                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionStatusId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>a64dd0fa2ea1e95ce521d585ad2fccf2</Hash>
</Codenesium>*/