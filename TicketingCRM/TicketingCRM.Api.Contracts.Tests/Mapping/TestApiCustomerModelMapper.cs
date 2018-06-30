using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Customer")]
        [Trait("Area", "ApiModel")]
        public class TestApiCustomerModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCustomerModelMapper();
                        var model = new ApiCustomerRequestModel();
                        model.SetProperties("A", "A", "A", "A");
                        ApiCustomerResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCustomerModelMapper();
                        var model = new ApiCustomerResponseModel();
                        model.SetProperties(1, "A", "A", "A", "A");
                        ApiCustomerRequestModel response = mapper.MapResponseToRequest(model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>e0435b2316524663a4517896b84574a0</Hash>
</Codenesium>*/