using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CountryRegion")]
        [Trait("Area", "ApiModel")]
        public class TestApiCountryRegionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCountryRegionModelMapper();
                        var model = new ApiCountryRegionRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCountryRegionResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.CountryRegionCode.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCountryRegionModelMapper();
                        var model = new ApiCountryRegionResponseModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCountryRegionRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiCountryRegionModelMapper();
                        var model = new ApiCountryRegionRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JsonPatchDocument<ApiCountryRegionRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiCountryRegionRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>86d3b77e5aaac6cca87cc0a4cd5bbc28</Hash>
</Codenesium>*/