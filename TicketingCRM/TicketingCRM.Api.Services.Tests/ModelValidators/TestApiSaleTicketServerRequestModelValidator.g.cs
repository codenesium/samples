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
	public partial class ApiSaleTicketServerRequestModelValidatorTest
	{
		public ApiSaleTicketServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void SaleId_Create_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(new Sale()));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void SaleId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.SaleBySaleId(It.IsAny<int>())).Returns(Task.FromResult<Sale>(null));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.SaleId, 1);
		}

		[Fact]
		public async void TicketId_Create_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateCreateAsync(new ApiSaleTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Create_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateCreateAsync(new ApiSaleTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Valid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(new Ticket()));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketId, 1);
		}

		[Fact]
		public async void TicketId_Update_Invalid_Reference()
		{
			Mock<ISaleTicketRepository> saleTicketRepository = new Mock<ISaleTicketRepository>();
			saleTicketRepository.Setup(x => x.TicketByTicketId(It.IsAny<int>())).Returns(Task.FromResult<Ticket>(null));

			var validator = new ApiSaleTicketServerRequestModelValidator(saleTicketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiSaleTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>90840caa5dbe1ac520b5d997af340011</Hash>
</Codenesium>*/