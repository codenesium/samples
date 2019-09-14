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
	[Trait("Table", "Sale")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSaleServerRequestModelValidatorTest
	{
		public ApiSaleServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void IpAddress_Create_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
		}

		[Fact]
		public async void IpAddress_Update_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
		}

		[Fact]
		public async void IpAddress_Create_length()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
		}

		[Fact]
		public async void IpAddress_Update_length()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
		}

		[Fact]
		public async void Notes_Create_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
		}

		[Fact]
		public async void Notes_Update_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Notes, null as string);
		}

		[Fact]
		public async void TransactionId_Create_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.TransactionByTransactionId(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Create_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.TransactionByTransactionId(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Update_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.TransactionByTransactionId(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Update_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.TransactionByTransactionId(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

			var validator = new ApiSaleServerRequestModelValidator(saleRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>5502e9afb695caf27b2b71d17a4aa18a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/