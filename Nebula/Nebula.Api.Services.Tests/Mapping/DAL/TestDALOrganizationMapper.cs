using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Organization")]
        [Trait("Area", "DALMapper")]
        public class TestDALOrganizationMapper
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

                        BOOrganization response = mapper.MapEFToBO(entity);

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
    <Hash>dbd7b403d793c92881f570b6c8b37e56</Hash>
</Codenesium>*/