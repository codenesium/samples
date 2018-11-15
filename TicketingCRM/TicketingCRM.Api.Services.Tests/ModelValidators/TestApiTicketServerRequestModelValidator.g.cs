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
	[Trait("Table", "Ticket")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTicketServerRequestModelValidatorTest
	{
		public ApiTicketServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void PublicId_Create_null()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
		}

		[Fact]
		public async void PublicId_Update_null()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
		}

		[Fact]
		public async void PublicId_Create_length()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
		}

		[Fact]
		public async void PublicId_Update_length()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
		}

		[Fact]
		public async void TicketStatusId_Create_Valid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(new TicketStatu()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Create_Invalid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);

			await validator.ValidateCreateAsync(new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Update_Valid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(new TicketStatu()));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketServerRequestModel());

			validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}

		[Fact]
		public async void TicketStatusId_Update_Invalid_Reference()
		{
			Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
			ticketRepository.Setup(x => x.TicketStatuByTicketStatusId(It.IsAny<int>())).Returns(Task.FromResult<TicketStatu>(null));

			var validator = new ApiTicketServerRequestModelValidator(ticketRepository.Object);

			await validator.ValidateUpdateAsync(default(int), new ApiTicketServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
		}
	}
}

/*<Codenesium>
    <Hash>90b339885f1f7732b3b44eddf3910c3f</Hash>
</Codenesium>*/