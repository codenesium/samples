using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TagSet")]
	[Trait("Area", "DALMapper")]
	public class TestDALTagSetMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTagSetMapper();
			var bo = new BOTagSet();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A", 1);

			TagSet response = mapper.MapBOToEF(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTagSetMapper();
			TagSet entity = new TagSet();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

			BOTagSet response = mapper.MapEFToBO(entity);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTagSetMapper();
			TagSet entity = new TagSet();
			entity.SetProperties(BitConverter.GetBytes(1), "A", "A", "A", 1);

			List<BOTagSet> response = mapper.MapEFToBO(new List<TagSet>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>64d1a450f9413976f12d0aaf04784b94</Hash>
</Codenesium>*/