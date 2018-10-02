using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "VPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALVPersonMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALVPersonMapper();
			var bo = new BOVPerson();
			bo.SetProperties(1, "A");

			VPerson response = mapper.MapBOToEF(bo);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALVPersonMapper();
			VPerson entity = new VPerson();
			entity.SetProperties(1, "A");

			BOVPerson response = mapper.MapEFToBO(entity);

			response.PersonId.Should().Be(1);
			response.PersonName.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALVPersonMapper();
			VPerson entity = new VPerson();
			entity.SetProperties(1, "A");

			List<BOVPerson> response = mapper.MapEFToBO(new List<VPerson>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1ccc4e999f33c3fd43afb450b750f6e8</Hash>
</Codenesium>*/