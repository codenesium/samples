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
                        await validator.ValidateUpdateAsync(default(int), new ApiTicketStatusRequestModel());

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
                        await validator.ValidateUpdateAsync(default(int), new ApiTicketStatusRequestModel());

                        validator.ShouldHaveValidationErrorFor(x => x.Name, new string('A', 129));
                }
        }
}

/*<Codenesium>
    <Hash>8872a3f882d561e506755cb57a9fda48</Hash>
</Codenesium>*/