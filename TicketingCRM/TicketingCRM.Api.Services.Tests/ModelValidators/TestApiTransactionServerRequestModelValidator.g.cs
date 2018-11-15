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
	public partial class ApiTransactionServerRequestModelValidatorTest
	{
		public ApiTransactionServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void GatewayConfirmationNumber_Create_null()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, null as string);
		}

		[Fact]
		public async void GatewayConfirmationNumber_Update_null()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, null as string);
		}

		[Fact]
		public async void GatewayConfirmationNumber_Create_length()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, new string('A', 2));
		}

		[Fact]
		public async void GatewayConfirmationNumber_Update_length()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Transaction()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.GatewayConfirmationNumber, new string('A', 2));
		}

		[Fact]
		public async void TransactionStatusId_Create_Valid_Reference()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.TransactionStatuByTransactionStatusId(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(new TransactionStatu()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionStatusId, 1);
		}

		[Fact]
		public async void TransactionStatusId_Create_Invalid_Reference()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.TransactionStatuByTransactionStatusId(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(null));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);

			await validator.ValidateCreateAsync(new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionStatusId, 1);
		}

		[Fact]
		public async void TransactionStatusId_Update_Valid_Reference()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.TransactionStatuByTransactionStatusId(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(new TransactionStatu()));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionStatusId, 1);
		}

		[Fact]
		public async void TransactionStatusId_Update_Invalid_Reference()
		{
			Mock<ITransactionRepository> transactionRepository = new Mock<ITransactionRepository>();
			transactionRepository.Setup(x => x.TransactionStatuByTransactionStatusId(It.IsAny<int>())).Returns(Task.FromResult<TransactionStatu>(null));

			var validator = new ApiTransactionServerRequestModelValidator(transactionRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTransactionServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>cadac691a8d80038f09c6dfbdbbd0c9e</Hash>
</Codenesium>*/