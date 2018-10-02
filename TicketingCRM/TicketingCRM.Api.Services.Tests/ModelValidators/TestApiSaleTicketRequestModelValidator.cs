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
	[Trait("Table", "SaleTicket")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiSaleTicketRequestModelValidatorTest
	{
		public ApiSaleTicketRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SaleId_Create_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetSale(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void TicketId_Create_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.GetTicket(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>981c3bea3ea6c5b2f4eda4ae190c6057</Hash>
</Codenesium>*/