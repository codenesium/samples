using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "DALMapper")]
	public class TestDALTimestampCheckMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTimestampCheckMapper();
			var bo = new BOTimestampCheck();
			bo.SetProperties(1, "A", BitConverter.GetBytes(1));

			TimestampCheck response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTimestampCheckMapper();
			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(1, "A", BitConverter.GetBytes(1));

			BOTimestampCheck response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTimestampCheckMapper();
			TimestampCheck entity = new TimestampCheck();
			entity.SetProperties(1, "A", BitConverter.GetBytes(1));

			List<BOTimestampCheck> response = mapper.MapEFToBO(new List<TimestampCheck>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ff3d83780587730358269cc9096abc80</Hash>
</Codenesium>*/