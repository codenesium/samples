using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TenantVariable")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLTenantVariableActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLTenantVariableMapper();

                        ApiTenantVariableRequestModel model = new ApiTenantVariableRequestModel();

                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        BOTenantVariable response = mapper.MapModelToBO("A", model);

                        response.EnvironmentId.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLTenantVariableMapper();

                        BOTenantVariable bo = new BOTenantVariable();

                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        ApiTenantVariableResponseModel response = mapper.MapBOToModel(bo);

                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLTenantVariableMapper();

                        BOTenantVariable bo = new BOTenantVariable();

                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        List<ApiTenantVariableResponseModel> response = mapper.MapBOToModel(new List<BOTenantVariable>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8e74f6b410d3f8af22c92b5749b74aef</Hash>
</Codenesium>*/