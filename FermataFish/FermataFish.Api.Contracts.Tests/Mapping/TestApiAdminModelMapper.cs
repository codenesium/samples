using FermataFishNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
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
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        ApiAdminResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAdminModelMapper();
                        var model = new ApiAdminResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
                        ApiAdminRequestModel response = mapper.MapResponseToRequest(model);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiAdminModelMapper();
                        var model = new ApiAdminRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);

                        JsonPatchDocument<ApiAdminRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiAdminRequestModel();
                        patch.ApplyTo(response);

                        response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8e82e2e4d14ea52efda79ddae33d29ec</Hash>
</Codenesium>*/