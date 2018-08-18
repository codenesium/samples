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
    <Hash>8fdb24b4f46373ee49b3183b797230f0</Hash>
</Codenesium>*/