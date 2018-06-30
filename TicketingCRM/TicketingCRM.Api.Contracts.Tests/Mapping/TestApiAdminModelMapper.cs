using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Admin")]
        [Trait("Area", "ApiModel")]
        public class TestApiAdminModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAdminModelMapper();
                        var model = new ApiAdminRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        ApiAdminResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Password.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.Username.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAdminModelMapper();
                        var model = new ApiAdminResponseModel();
                        model.SetProperties(1, "A", "A", "A", "A", "A", "A");
                        ApiAdminRequestModel response = mapper.MapResponseToRequest(model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Password.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.Username.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a7c491076720f1893dfc6ca73a844516</Hash>
</Codenesium>*/