using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Account")]
        [Trait("Area", "ApiModel")]
        public class TestApiAccountModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiAccountModelMapper();
                        var model = new ApiAccountRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        ApiAccountResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiAccountModelMapper();
                        var model = new ApiAccountResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        ApiAccountRequestModel response = mapper.MapResponseToRequest(model);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>867e28cd762af4260e7d86ebb21dd3ea</Hash>
</Codenesium>*/