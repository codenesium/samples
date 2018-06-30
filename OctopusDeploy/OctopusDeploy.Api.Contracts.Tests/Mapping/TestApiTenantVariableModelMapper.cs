using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TenantVariable")]
        [Trait("Area", "ApiModel")]
        public class TestApiTenantVariableModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiTenantVariableModelMapper();
                        var model = new ApiTenantVariableRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        ApiTenantVariableResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiTenantVariableModelMapper();
                        var model = new ApiTenantVariableResponseModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        ApiTenantVariableRequestModel response = mapper.MapResponseToRequest(model);

                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>f4db8d7b8709c8db4bb49235daa4da9a</Hash>
</Codenesium>*/