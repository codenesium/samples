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
        [Trait("Table", "TransactionHistoryArchive")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTransactionHistoryArchiveRequestModelValidatorTest
        {
                public ApiTransactionHistoryArchiveRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void TransactionType_Create_null()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionHistoryArchiveRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
                }

                [Fact]
                public async void TransactionType_Update_null()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionHistoryArchiveRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
                }

                [Fact]
                public async void TransactionType_Create_length()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTransactionHistoryArchiveRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
                }

                [Fact]
                public async void TransactionType_Update_length()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTransactionHistoryArchiveRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
                }

                [Fact]
                public async void TransactionType_Delete()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>9bcd813ba2acd6f8ba62391fa23be0cc</Hash>
</Codenesium>*/