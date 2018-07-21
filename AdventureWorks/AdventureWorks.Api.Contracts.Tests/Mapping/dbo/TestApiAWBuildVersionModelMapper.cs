using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AWBuildVersion")]
        [Trait("Area", "ApiModel")]
        public class TestApiAWBuildVersionModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAWBuildVersionModelMapper();
                        var model = new ApiAWBuildVersionRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiAWBuildVersionResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Database_Version.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SystemInformationID.Should().Be(1);
                        response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAWBuildVersionModelMapper();
                        var model = new ApiAWBuildVersionResponseModel();
                        model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiAWBuildVersionRequestModel response = mapper.MapResponseToRequest(model);

                        response.Database_Version.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiAWBuildVersionModelMapper();
                        var model = new ApiAWBuildVersionRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"));

                        JsonPatchDocument<ApiAWBuildVersionRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiAWBuildVersionRequestModel();
                        patch.ApplyTo(response);

                        response.Database_Version.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.VersionDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>352ae713efddb62d2c327867306ccbd7</Hash>
</Codenesium>*/