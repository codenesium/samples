using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TicketStatus")]
        [Trait("Area", "ApiModel")]
        public class TestApiTicketStatusModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTicketStatusModelMapper();
                        var model = new ApiTicketStatusRequestModel();
                        model.SetProperties("A");
                        ApiTicketStatusResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTicketStatusModelMapper();
                        var model = new ApiTicketStatusResponseModel();
                        model.SetProperties(1, "A");
                        ApiTicketStatusRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>6b81db14094092ecf0d66e72650848ab</Hash>
</Codenesium>*/