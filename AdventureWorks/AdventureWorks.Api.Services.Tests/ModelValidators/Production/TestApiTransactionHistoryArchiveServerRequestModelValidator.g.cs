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
	public partial class ApiTransactionHistoryArchiveServerRequestModelValidatorTest
	{
		public ApiTransactionHistoryArchiveServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void TransactionType_Create_null()
		{
			Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
			transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

			var validator = new ApiTransactionHistoryArchiveServerRequestModelValidator(transactionHistoryArchiveRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionHistoryArchiveServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
		}

		[Fact]
		public async void TransactionType_Update_null()
		{
			Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
			transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

			var validator = new ApiTransactionHistoryArchiveServerRequestModelValidator(transactionHistoryArchiveRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryArchiveServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
		}

		[Fact]
		public async void TransactionType_Create_length()
		{
			Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
			transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

			var validator = new ApiTransactionHistoryArchiveServerRequestModelValidator(transactionHistoryArchiveRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionHistoryArchiveServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
		}

		[Fact]
		public async void TransactionType_Update_length()
		{
			Mock<ITransactionHistoryArchiveRepository> transactionHistoryArchiveRepository = new Mock<ITransactionHistoryArchiveRepository>();
			transactionHistoryArchiveRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistoryArchive()));

			var validator = new ApiTransactionHistoryArchiveServerRequestModelValidator(transactionHistoryArchiveRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryArchiveServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>8202635ce923a30bb640d89081e92f31</Hash>
</Codenesium>*/