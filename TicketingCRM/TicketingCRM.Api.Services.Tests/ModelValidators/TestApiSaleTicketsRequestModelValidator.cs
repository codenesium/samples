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
	public partial class ApiSaleTicketsRequestModelValidatorTest
	{
		public ApiSaleTicketsRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SaleId_Create_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void TicketId_Create_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Valid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketsRepository> saleTicketsRepository = new Mock<ISaleTicketsRepository>();
			saleTicketsRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketsRequestModelValidator(saleTicketsRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketsRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>d471af5f1a9af85745abba1d57d35f3d</Hash>
</Codenesium>*/