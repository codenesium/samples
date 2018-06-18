using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Account")]
        [Trait("Area", "DALMapper")]
        public class TestDALAccountActionMapper
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

                        BOAccount  response = mapper.MapEFToBO(entity);

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
    <Hash>96f5fc5c0d69b7a8d6b68496fee8cdee</Hash>
</Codenesium>*/