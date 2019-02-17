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
	public partial class ApiTransactionStatusServerRequestModelValidatorTest
	{
		public ApiTransactionStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
			transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

			var validator = new ApiTransactionStatusServerRequestModelValidator(transactionStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
			transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

			var validator = new ApiTransactionStatusServerRequestModelValidator(transactionStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
			transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

			var validator = new ApiTransactionStatusServerRequestModelValidator(transactionStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITransactionStatusRepository> transactionStatusRepository = new Mock<ITransactionStatusRepository>();
			transactionStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatus()));

			var validator = new ApiTransactionStatusServerRequestModelValidator(transactionStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>9a7415d9d034b09a75bb6c8ca9e96578</Hash>
</Codenesium>*/