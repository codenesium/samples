using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPostHistoryTypeMapper();
			var bo = new BOPostHistoryType();
			bo.SetProperties(1, "A");

			PostHistoryType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPostHistoryTypeMapper();
			PostHistoryType entity = new PostHistoryType();
			entity.SetProperties(1, "A");

			BOPostHistoryType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPostHistoryTypeMapper();
			PostHistoryType entity = new PostHistoryType();
			entity.SetProperties(1, "A");

			List<BOPostHistoryType> response = mapper.MapEFToBO(new List<PostHistoryType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>54d5a185aee676f1a63c585bc77f3cf3</Hash>
</Codenesium>*/