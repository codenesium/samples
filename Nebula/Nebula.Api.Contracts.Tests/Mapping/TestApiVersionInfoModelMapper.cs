using FluentAssertions;
using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "VersionInfo")]
        [Trait("Area", "ApiModel")]
        public class TestApiVersionInfoModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiVersionInfoModelMapper();
                        var model = new ApiVersionInfoRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiVersionInfoResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                        response.Version.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiVersionInfoModelMapper();
                        var model = new ApiVersionInfoResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiVersionInfoRequestModel response = mapper.MapResponseToRequest(model);

                        response.AppliedOn.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Description.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>a90b1d92534547ddde0b705a5f2abf65</Hash>
</Codenesium>*/