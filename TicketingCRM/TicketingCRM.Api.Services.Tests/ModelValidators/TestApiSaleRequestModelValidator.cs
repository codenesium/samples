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
	public partial class ApiSaleRequestModelValidatorTest
	{
		public ApiSaleRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void IpAddress_Create_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
		}

		[Fact]
		public async void IpAddress_Update_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, null as string);
		}

		[Fact]
		public async void IpAddress_Create_length()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
		}

		[Fact]
		public async void IpAddress_Update_length()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.IpAddress, new string('A', 129));
		}

		[Fact]
		public async void Note_Create_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void Note_Update_null()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Sale()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Note, null as string);
		}

		[Fact]
		public async void TransactionId_Create_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Create_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Update_Valid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(new Transaction()));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TransactionId, 1);
		}

		[Fact]
		public async void TransactionId_Update_Invalid_Reference()
		{
			Mock<ISaleRepository> saleRepository = new Mock<ISaleRepository>();
			saleRepository.Setup(x => x.GetTransaction(It.IsAny<int>())).Returns(Task.FromResult<Transaction>(null));

			var validator = new ApiSaleRequestModelValidator(saleRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TransactionId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>8cb3d52b66b38b7a001325a72843623e</Hash>
</Codenesium>*/