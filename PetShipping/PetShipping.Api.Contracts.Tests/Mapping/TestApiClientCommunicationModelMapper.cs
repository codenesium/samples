using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ClientCommunication")]
        [Trait("Area", "ApiModel")]
        public class TestApiClientCommunicationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiClientCommunicationModelMapper();
                        var model = new ApiClientCommunicationRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        ApiClientCommunicationResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Notes.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiClientCommunicationModelMapper();
                        var model = new ApiClientCommunicationResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");
                        ApiClientCommunicationRequestModel response = mapper.MapResponseToRequest(model);

                        response.ClientId.Should().Be(1);
                        response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.EmployeeId.Should().Be(1);
                        response.Notes.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>6d5d0457e59af4f84e72ad2457398edd</Hash>
</Codenesium>*/