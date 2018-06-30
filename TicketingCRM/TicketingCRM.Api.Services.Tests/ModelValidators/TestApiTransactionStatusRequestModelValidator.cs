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
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatusRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>83c543099691d9c7facda403d3e5236f</Hash>
</Codenesium>*/