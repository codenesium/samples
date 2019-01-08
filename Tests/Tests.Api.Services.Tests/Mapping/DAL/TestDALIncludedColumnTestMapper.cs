using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "IncludedColumnTest")]
	[Trait("Area", "DALMapper")]
	public class TestDALIncludedColumnTestMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALIncludedColumnTestMapper();
			var bo = new BOIncludedColumnTest();
			bo.SetProperties(1, "A", "A");

			IncludedColumnTest response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALIncludedColumnTestMapper();
			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(1, "A", "A");

			BOIncludedColumnTest response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Name2.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALIncludedColumnTestMapper();
			IncludedColumnTest entity = new IncludedColumnTest();
			entity.SetProperties(1, "A", "A");

			List<BOIncludedColumnTest> response = mapper.MapEFToBO(new List<IncludedColumnTest>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6af73e80e362a38b8917dd6999e3b52e</Hash>
</Codenesium>*/