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
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTicketStatusServerRequestModelValidatorTest
	{
		public ApiTicketStatusServerRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
			ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

			var validator = new ApiTicketStatusServerRequestModelValidator(ticketStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
			ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

			var validator = new ApiTicketStatusServerRequestModelValidator(ticketStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
			ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

			var validator = new ApiTicketStatusServerRequestModelValidator(ticketStatusRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
			ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

			var validator = new ApiTicketStatusServerRequestModelValidator(ticketStatusRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketStatusServerRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>6ecf7ee808be861dd550c2e07dc3a157</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/