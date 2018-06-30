using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Transaction")]
        [Trait("Area", "ApiModel")]
        public class TestApiTransactionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTransactionModelMapper();
                        var model = new ApiTransactionRequestModel();
                        model.SetProperties(1, "A", 1);
                        ApiTransactionResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Amount.Should().Be(1);
                        response.GatewayConfirmationNumber.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.TransactionStatusId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTransactionModelMapper();
                        var model = new ApiTransactionResponseModel();
                        model.SetProperties(1, 1, "A", 1);
                        ApiTransactionRequestModel response = mapper.MapResponseToRequest(model);

                        response.Amount.Should().Be(1);
                        response.GatewayConfirmationNumber.Should().Be("A");
                        response.TransactionStatusId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fe3ffc0dc5c72ec52b8247117bf65249</Hash>
</Codenesium>*/