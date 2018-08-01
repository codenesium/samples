using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "State")]
	[Trait("Area", "DALMapper")]
	public class TestDALStateMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALStateMapper();
			var bo = new BOState();
			bo.SetProperties(1, "A");

			State response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALStateMapper();
			State entity = new State();
			entity.SetProperties(1, "A");

			BOState response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALStateMapper();
			State entity = new State();
			entity.SetProperties(1, "A");

			List<BOState> response = mapper.MapEFToBO(new List<State>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4950a82119ed4f62f7532f7cc59316c9</Hash>
</Codenesium>*/