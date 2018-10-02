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
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "ModelValidators")]
	public partial class ApiTicketStatuRequestModelValidatorTest
	{
		public ApiTicketStatuRequestModelValidatorTest()
		{
		}

		[Fact]
		public async void Name_Create_null()
		{
			Mock<ITicketStatuRepository> ticketStatuRepository = new Mock<ITicketStatuRepository>();
			ticketStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));

			var validator = new ApiTicketStatuRequestModelValidator(ticketStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Update_null()
		{
			Mock<ITicketStatuRepository> ticketStatuRepository = new Mock<ITicketStatuRepository>();
			ticketStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));

			var validator = new ApiTicketStatuRequestModelValidator(ticketStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
		}

		[Fact]
		public async void Name_Create_length()
		{
			Mock<ITicketStatuRepository> ticketStatuRepository = new Mock<ITicketStatuRepository>();
			ticketStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));

			var validator = new ApiTicketStatuRequestModelValidator(ticketStatuRepository.Object);
			await validator.ValidateCreateAsync(new ApiTicketStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}

		[Fact]
		public async void Name_Update_length()
		{
			Mock<ITicketStatuRepository> ticketStatuRepository = new Mock<ITicketStatuRepository>();
			ticketStatuRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatu()));

			var validator = new ApiTicketStatuRequestModelValidator(ticketStatuRepository.Object);
			await validator.ValidateUpdateAsync(default(int), new ApiTicketStatuRequestModel());

			validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
		}
	}
}

/*<Codenesium>
    <Hash>b0202a576357420d8b5747c2bb054c94</Hash>
</Codenesium>*/