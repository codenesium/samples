using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Organization")]
        [Trait("Area", "DALMapper")]
        public class TestDALOrganizationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALOrganizationMapper();

                        var bo = new BOOrganization();

                        bo.SetProperties(1, "A");

                        Organization response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALOrganizationMapper();

                        Organization entity = new Organization();

                        entity.SetProperties(1, "A");

                        BOOrganization  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALOrganizationMapper();

                        Organization entity = new Organization();

                        entity.SetProperties(1, "A");

                        List<BOOrganization> response = mapper.MapEFToBO(new List<Organization>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>f833785368a70a4afa8a0cd11d14b9ab</Hash>
</Codenesium>*/