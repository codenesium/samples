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
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTransactionStatuServerRequestModelValidatorTest
	{
		public ApiTransactionStatuServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITransactionStatuRepository> transactionStatuRepository = new Mock<ITransactionStatuRepository>();
			transactionStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));

			var validator = new ApiTransactionStatuServerRequestModelValidator(transactionStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITransactionStatuRepository> transactionStatuRepository = new Mock<ITransactionStatuRepository>();
			transactionStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));

			var validator = new ApiTransactionStatuServerRequestModelValidator(transactionStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITransactionStatuRepository> transactionStatuRepository = new Mock<ITransactionStatuRepository>();
			transactionStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));

			var validator = new ApiTransactionStatuServerRequestModelValidator(transactionStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITransactionStatuRepository> transactionStatuRepository = new Mock<ITransactionStatuRepository>();
			transactionStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionStatu()));

			var validator = new ApiTransactionStatuServerRequestModelValidator(transactionStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionStatuServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>5c6b4745017e37d6d79c3e79f4df08ef</Hash>
</Codenesium>*/