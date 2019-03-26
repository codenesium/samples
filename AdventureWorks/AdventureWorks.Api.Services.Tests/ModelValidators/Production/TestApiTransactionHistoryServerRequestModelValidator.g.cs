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
	public partial class ApiTransactionHistoryServerRequestModelValidatorTest
	{
		public ApiTransactionHistoryServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void ProductID_Create_Valid_Reference()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Create_Invalid_Reference()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);

			await validator.ValidateCreateAsync(new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Valid_Reference()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(new Product()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void ProductID_Update_Invalid_Reference()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.ProductByProductID(It.IsAny<int>())).Returns(Task.FromResult<Product>(null));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.ProductID, 1);
		}

		[Fact]
		public async void TransactionType_Create_null()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
		}

		[Fact]
		public async void TransactionType_Update_null()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, null as string);
		}

		[Fact]
		public async void TransactionType_Create_length()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateCreateAsync(new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
		}

		[Fact]
		public async void TransactionType_Update_length()
		{
			Mock<ITransactionHistoryRepository> transactionHistoryRepository = new Mock<ITransactionHistoryRepository>();
			transactionHistoryRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TransactionHistory()));

			var validator = new ApiTransactionHistoryServerRequestModelValidator(transactionHistoryRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTransactionHistoryServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionType, new string('A', 2));
		}
	}
}

/*<Codenesium>
    <Hash>1b4cb24b2a5a5b7fd17b16e2815c931c</Hash>
</Codenesium>*/