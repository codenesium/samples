using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityContact")]
        [Trait("Area", "ApiModel")]
        public class TestApiBusinessEntityContactModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiBusinessEntityContactModelMapper();
                        var model = new ApiBusinessEntityContactRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityContactResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PersonID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiBusinessEntityContactModelMapper();
                        var model = new ApiBusinessEntityContactResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityContactRequestModel response = mapper.MapResponseToRequest(model);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PersonID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiBusinessEntityContactModelMapper();
                        var model = new ApiBusinessEntityContactRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        JsonPatchDocument<ApiBusinessEntityContactRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiBusinessEntityContactRequestModel();
                        patch.ApplyTo(response);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.PersonID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }
        }
}

/*<Codenesium>
    <Hash>dc41afb038823b0c465f8b96d98f4ed7</Hash>
</Codenesium>*/