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
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryArchiveRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryArchiveRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
                }

                [Fact]
                public async void TransactionType_Delete()
                {
                        Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
                        transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

                        var validator = new ApiTransactionHistoryArchiveRequestModelValidator(transactionHistoryArchiveRepository.Object);
                        ValidationResult response = await validator.ValidateDeleteAsync(default(int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>c3c7768c5f8ff26c3fb30b7c0c64a37d</Hash>
</Codenesium>*/