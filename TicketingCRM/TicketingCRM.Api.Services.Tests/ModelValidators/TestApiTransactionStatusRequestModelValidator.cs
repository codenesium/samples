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
        [Trait("Table", "TransactionStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTransactionStatusRequestModelValidatorTest
        {
                public ApiTransactionStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
                        transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

                        var validator = new ApiTransactionStatusRequestModelValidator(transactionStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
                        transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

                        var validator = new ApiTransactionStatusRequestModelValidator(transactionStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
                        transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

                        var validator = new ApiTransactionStatusRequestModelValidator(transactionStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
                        transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

                        var validator = new ApiTransactionStatusRequestModelValidator(transactionStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
                        transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

                        var validator = new ApiTransactionStatusRequestModelValidator(transactionStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>5aafa86f305926e35467fede012292a0</Hash>
</Codenesium>*/