using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Account")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLAccountMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLAccountMapper();
                        ApiAccountRequestModel model = new ApiAccountRequestModel();
                        model.SetProperties("A", "A", "A", "A", "A", "A");
                        BOAccount response = mapper.MapModelToBO("A", model);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLAccountMapper();
                        BOAccount bo = new BOAccount();
                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        ApiAccountResponseModel response = mapper.MapBOToModel(bo);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLAccountMapper();
                        BOAccount bo = new BOAccount();
                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");
                        List<ApiAccountResponseModel> response = mapper.MapBOToModel(new List<BOAccount>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b573c831d6dfb80d687ee5bd52e0b1d7</Hash>
</Codenesium>*/