using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Channel")]
        [Trait("Area", "DALMapper")]
        public class TestDALChannelActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALChannelMapper();

                        var bo = new BOChannel();

                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", "A", "A", "A");

                        Channel response = mapper.MapBOToEF(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALChannelMapper();

                        Channel entity = new Channel();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A", "A");

                        BOChannel  response = mapper.MapEFToBO(entity);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.LifecycleId.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.ProjectId.Should().Be("A");
                        response.TenantTags.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALChannelMapper();

                        Channel entity = new Channel();

                        entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", "A", "A", "A");

                        List<BOChannel> response = mapper.MapEFToBO(new List<Channel>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>703cb68582e00f4d029aa1203113bcff</Hash>
</Codenesium>*/