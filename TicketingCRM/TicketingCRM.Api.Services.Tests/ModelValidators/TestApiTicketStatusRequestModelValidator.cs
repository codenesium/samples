using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Results;
using FluentValidation.TestHelper;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TicketStatus")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTicketStatusRequestModelValidatorTest
        {
                public ApiTicketStatusRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void Name_Create_null()
                {
                        Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
                        ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

                        var validator = new ApiTicketStatusRequestModelValidator(ticketStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Update_null()
                {
                        Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
                        ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

                        var validator = new ApiTicketStatusRequestModelValidator(ticketStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
                }

                [Fact]
                public async void Name_Create_length()
                {
                        Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
                        ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

                        var validator = new ApiTicketStatusRequestModelValidator(ticketStatusRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Update_length()
                {
                        Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
                        ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

                        var validator = new ApiTicketStatusRequestModelValidator(ticketStatusRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }

                [Fact]
                public async void Name_Delete()
                {
                        Mock<ITicketStatusRepository> ticketStatusRepository = new Mock<ITicketStatusRepository>();
                        ticketStatusRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new TicketStatus()));

                        var validator = new ApiTicketStatusRequestModelValidator(ticketStatusRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }
        }
}

/*<Codenesium>
    <Hash>4076042f6173d44585a90f6f13a6fc14</Hash>
</Codenesium>*/