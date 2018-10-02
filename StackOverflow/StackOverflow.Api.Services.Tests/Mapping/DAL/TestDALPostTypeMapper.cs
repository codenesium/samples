using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPostTypeMapper();
			var bo = new BOPostType();
			bo.SetProperties(1, "A");

			PostType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPostTypeMapper();
			PostType entity = new PostType();
			entity.SetProperties(1, "A");

			BOPostType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPostTypeMapper();
			PostType entity = new PostType();
			entity.SetProperties(1, "A");

			List<BOPostType> response = mapper.MapEFToBO(new List<PostType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ff589cdcb0f0f3ac5bb7a954450a4706</Hash>
</Codenesium>*/