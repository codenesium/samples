using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "UserRole")]
        [Trait("Area", "DALMapper")]
        public class TestDALUserRoleActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALUserRoleMapper();

                        var bo = new BOUserRole();

                        bo.SetProperties("A", "A", "A");

                        UserRole response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALUserRoleMapper();

                        UserRole entity = new UserRole();

                        entity.SetProperties("A", "A", "A");

                        BOUserRole  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALUserRoleMapper();

                        UserRole entity = new UserRole();

                        entity.SetProperties("A", "A", "A");

                        List<BOUserRole> response = mapper.MapEFToBO(new List<UserRole>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>566062761ad8df01ebfd01d876128a76</Hash>
</Codenesium>*/