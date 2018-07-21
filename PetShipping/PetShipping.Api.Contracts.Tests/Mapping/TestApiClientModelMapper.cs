using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Client")]
        [Trait("Area", "ApiModel")]
        public class TestApiClientModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiClientModelMapper();
                        var model = new ApiClientRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A");
                        ApiClientResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiClientModelMapper();
                        var model = new ApiClientResponseModel();
                        model.SetProperties(1, "A", "A", "A", "A", "A");
                        ApiClientRequestModel response = mapper.MapResponseToRequest(model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiClientModelMapper();
                        var model = new ApiClientRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A");

                        JsonPatchDocument<ApiClientRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiClientRequestModel();
                        patch.ApplyTo(response);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Notes.Should().Be("A");
                        response.Phone.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>7fdb59820944723f7b0d590e52e99f45</Hash>
</Codenesium>*/