using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ApiKey")]
        [Trait("Area", "ApiModel")]
        public class TestApiApiKeyModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiApiKeyModelMapper();
                        var model = new ApiApiKeyRequestModel();
                        model.SetProperties("A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        ApiApiKeyResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiApiKeyModelMapper();
                        var model = new ApiApiKeyResponseModel();
                        model.SetProperties("A", "A", DateTimeOffset.Parse("1/1/1987 12:00:00 AM"), "A", "A");
                        ApiApiKeyRequestModel response = mapper.MapResponseToRequest(model);

                        response.ApiKeyHashed.Should().Be("A");
                        response.Created.Should().Be(DateTimeOffset.Parse("1/1/1987 12:00:00 AM"));
                        response.JSON.Should().Be("A");
                        response.UserId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>d0023764b4790c26c5c11caf43e22f86</Hash>
</Codenesium>*/