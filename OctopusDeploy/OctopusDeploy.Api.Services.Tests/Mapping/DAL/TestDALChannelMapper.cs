using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Channel")]
	[Trait("Area", "DALMapper")]
	public class TestDALChannelMapper
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

			BOChannel response = mapper.MapEFToBO(entity);

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
    <Hash>0d6dda6caf2ae8f5a29f67d917508fb0</Hash>
</Codenesium>*/