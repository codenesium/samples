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
        [Trait("Table", "Ticket")]
        [Trait("Area", "ModelValidators")]
        public partial class ApiTicketRequestModelValidatorTest
        {
                public ApiTicketRequestModelValidatorTest()
                {
                }

                [Fact]
                public async void PublicId_Create_null()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
                }

                [Fact]
                public async void PublicId_Update_null()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, null as string);
                }

                [Fact]
                public async void PublicId_Create_length()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
                }

                [Fact]
                public async void PublicId_Update_length()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.PublicId, new string('A', 9));
                }

                [Fact]
                public async void PublicId_Delete()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(Task.FromResult(new Ticket()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        ValidationResult response = await validator.ValidateDeleteAsync(default (int));

                        response.Should().BeOfType(typeof(ValidationResult));
                }

                [Fact]
                public async void TicketStatusId_Create_Valid_Reference()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.GetTicketStatus(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(new TicketStatus()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
                }

                [Fact]
                public async void TicketStatusId_Create_Invalid_Reference()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.GetTicketStatus(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(null));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateCreateAsync(new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
                }

                [Fact]
                public async void TicketStatusId_Update_Valid_Reference()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.GetTicketStatus(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(new TicketStatus()));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketRequestModel());

                        validator.ShouldNotHaveValidationErrorFor(x => x.TicketStatusId, 1);
                }

                [Fact]
                public async void TicketStatusId_Update_Invalid_Reference()
                {
                        Mock<ITicketRepository> ticketRepository = new Mock<ITicketRepository>();
                        ticketRepository.Setup(x => x.GetTicketStatus(It.IsAny<int>())).Returns(Task.FromResult<TicketStatus>(null));

                        var validator = new ApiTicketRequestModelValidator(ticketRepository.Object);

                        await validator.ValidateUpdateAsync(default (int), new ApiTicketRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.TicketStatusId, 1);
                }
        }
}

/*<Codenesium>
    <Hash>e916873c1fdcee11322ca6784f9f2d13</Hash>
</Codenesium>*/