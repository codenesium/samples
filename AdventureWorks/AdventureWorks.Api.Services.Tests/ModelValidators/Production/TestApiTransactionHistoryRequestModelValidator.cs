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
        [Trait("Table", "TransactionHistory")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTransactionHistoryRequestModelValidatorTest
        {
                public ApiTransactionHistoryRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void TransactionType_Create_null()
                {
                        Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
                        transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

                        var validator = new ApiTransactionHistoryRequestModelValidator(transactionHistoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
                }

                [Fact]
                public async void TransactionType_Update_null()
                {
                        Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
                        transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

                        var validator = new ApiTransactionHistoryRequestModelValidator(transactionHistoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
                }

                [Fact]
                public async void TransactionType_Create_length()
                {
                        Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
                        transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

                        var validator = new ApiTransactionHistoryRequestModelValidator(transactionHistoryRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
                }

                [Fact]
                public async void TransactionType_Update_length()
                {
                        Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
                        transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

                        var validator = new ApiTransactionHistoryRequestModelValidator(transactionHistoryRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionHistoryRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
                }

                [Fact]
                public async void TransactionType_Delete()
                {
                        Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
                        transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

                        var validator = new ApiTransactionHistoryRequestModelValidator(transactionHistoryRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>fc4dd6e778db3128426aa091e249a700</Hash>
</Codenesium>*/