using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Account")]
        [Trait("Area", "DALMapper")]
        public class TestDALAccountMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALAccountMapper();
                        var bo = new BOAccount();
                        bo.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        Account response = mapper.MapBOToEF(bo);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALAccountMapper();
                        Account entity = new Account();
                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        BOAccount response = mapper.MapEFToBO(entity);

                        response.AccountType.Should().Be("A");
                        response.EnvironmentIds.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.TenantIds.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALAccountMapper();
                        Account entity = new Account();
                        entity.SetProperties("A", "A", "A", "A", "A", "A", "A");

                        List<BOAccount> response = mapper.MapEFToBO(new List<Account>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fa83702574abfb3b77b907de9e66d8ed</Hash>
</Codenesium>*/