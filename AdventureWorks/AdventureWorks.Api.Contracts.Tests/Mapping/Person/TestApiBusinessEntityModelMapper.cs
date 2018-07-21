using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntity")]
        [Trait("Area", "ApiModel")]
        public class TestApiBusinessEntityModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBusinessEntityModelMapper();
                        var model = new ApiBusinessEntityRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBusinessEntityModelMapper();
                        var model = new ApiBusinessEntityResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiBusinessEntityModelMapper();
                        var model = new ApiBusinessEntityRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        JsonPatchDocument<ApiBusinessEntityRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiBusinessEntityRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>5c3bb4dc00c84ba24c1d5c2f2dc99b68</Hash>
</Codenesium>*/