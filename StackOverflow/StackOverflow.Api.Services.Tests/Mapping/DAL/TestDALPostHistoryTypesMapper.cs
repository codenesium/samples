using FluentAssertions;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistoryTypes")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryTypesMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPostHistoryTypesMapper();
			var bo = new BOPostHistoryTypes();
			bo.SetProperties(1, "A");

			PostHistoryTypes response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPostHistoryTypesMapper();
			PostHistoryTypes entity = new PostHistoryTypes();
			entity.SetProperties(1, "A");

			BOPostHistoryTypes response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Type.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPostHistoryTypesMapper();
			PostHistoryTypes entity = new PostHistoryTypes();
			entity.SetProperties(1, "A");

			List<BOPostHistoryTypes> response = mapper.MapEFToBO(new List<PostHistoryTypes>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6571216119231d6622029dd968fdd24c</Hash>
</Codenesium>*/