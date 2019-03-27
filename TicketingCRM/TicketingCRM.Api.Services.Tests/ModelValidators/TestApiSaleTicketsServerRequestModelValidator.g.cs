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
	[Trait("Table", "SaleTickets")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSaleTicketsServerRequestModelValidatorTest
	{
		public ApiSaleTicketsServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SaleId_Create_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void TicketId_Create_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketsServerRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>c1798486be9c5851323c6c09be228be3</Hash>
</Codenesium>*/