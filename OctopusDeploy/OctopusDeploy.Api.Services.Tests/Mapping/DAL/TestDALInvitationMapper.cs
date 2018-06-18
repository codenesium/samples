using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Invitation")]
        [Trait("Area", "DALMapper")]
        public class TestDALInvitationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALInvitationMapper();

                        var bo = new BOInvitation();

                        bo.SetProperties("A", "A", "A");

                        Invitation response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALInvitationMapper();

                        Invitation entity = new Invitation();

                        entity.SetProperties("A", "A", "A");

                        BOInvitation  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.InvitationCode.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALInvitationMapper();

                        Invitation entity = new Invitation();

                        entity.SetProperties("A", "A", "A");

                        List<BOInvitation> response = mapper.MapEFToBO(new List<Invitation>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a43751931d499a5d2f38077a79081e99</Hash>
</Codenesium>*/