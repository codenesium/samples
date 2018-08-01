using FluentAssertions;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "LinkLog")]
	[Trait("Area", "DALMapper")]
	public class TestDALLinkLogMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALLinkLogMapper();
			var bo = new BOLinkLog();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			LinkLog response = mapper.MapBOToEF(bo);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALLinkLogMapper();
			LinkLog entity = new LinkLog();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			BOLinkLog response = mapper.MapEFToBO(entity);

			response.DateEntered.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkId.Should().Be(1);
			response.Log.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALLinkLogMapper();
			LinkLog entity = new LinkLog();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			List<BOLinkLog> response = mapper.MapEFToBO(new List<LinkLog>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c5506bec566dccde42f6eb43e633faf4</Hash>
</Codenesium>*/