using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "TenantVariable")]
        [Trait("Area", "DALMapper")]
        public class TestDALTenantVariableActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALTenantVariableMapper();

                        var bo = new BOTenantVariable();

                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        TenantVariable response = mapper.MapBOToEF(bo);

                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALTenantVariableMapper();

                        TenantVariable entity = new TenantVariable();

                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        BOTenantVariable  response = mapper.MapEFToBO(entity);

                        response.EnvironmentId.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.OwnerId.Should().Be("A");
                        response.RelatedDocumentId.Should().Be("A");
                        response.TenantId.Should().Be("A");
                        response.VariableTemplateId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALTenantVariableMapper();

                        TenantVariable entity = new TenantVariable();

                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        List<BOTenantVariable> response = mapper.MapEFToBO(new List<TenantVariable>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>eb1e46d416930ba735536802208ceb18</Hash>
</Codenesium>*/