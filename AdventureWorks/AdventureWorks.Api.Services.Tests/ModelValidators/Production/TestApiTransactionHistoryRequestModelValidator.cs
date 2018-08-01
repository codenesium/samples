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
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryRequestModel());

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
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>f5d0dd287857d5984f86cd7fb38e5d64</Hash>
</Codenesium>*/