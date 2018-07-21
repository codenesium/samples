using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ScrapReason")]
        [Trait("Area", "ApiModel")]
        public class TestApiScrapReasonModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiScrapReasonModelMapper();
                        var model = new ApiScrapReasonRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiScrapReasonResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ScrapReasonID.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiScrapReasonModelMapper();
                        var model = new ApiScrapReasonResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiScrapReasonRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiScrapReasonModelMapper();
                        var model = new ApiScrapReasonRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JsonPatchDocument<ApiScrapReasonRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiScrapReasonRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>5608f84f52f55abd07de37c04c1a6497</Hash>
</Codenesium>*/