using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Ticket")]
        [Trait("Area", "ApiModel")]
        public class TestApiTicketModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTicketModelMapper();
                        var model = new ApiTicketRequestModel();
                        model.SetProperties("A", 1);
                        ApiTicketResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.PublicId.Should().Be("A");
                        response.TicketStatusId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTicketModelMapper();
                        var model = new ApiTicketResponseModel();
                        model.SetProperties(1, "A", 1);
                        ApiTicketRequestModel response = mapper.MapResponseToRequest(model);

                        response.PublicId.Should().Be("A");
                        response.TicketStatusId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>6cc2cfad159550bd5aaa3736338e5b43</Hash>
</Codenesium>*/