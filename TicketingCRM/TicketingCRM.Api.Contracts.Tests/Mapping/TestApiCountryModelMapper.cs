using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Country")]
        [Trait("Area", "ApiModel")]
        public class TestApiCountryModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCountryModelMapper();
                        var model = new ApiCountryRequestModel();
                        model.SetProperties("A");
                        ApiCountryResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCountryModelMapper();
                        var model = new ApiCountryResponseModel();
                        model.SetProperties(1, "A");
                        ApiCountryRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiCountryModelMapper();
                        var model = new ApiCountryRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiCountryRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiCountryRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>b7fb4d327f84b63a03d3167c183ce551</Hash>
</Codenesium>*/