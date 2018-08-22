using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "DALMapper")]
	public class TestDALStudioMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALStudioMapper();
			var bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");

			Studio response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALStudioMapper();
			Studio entity = new Studio();
			entity.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");

			BOStudio response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALStudioMapper();
			Studio entity = new Studio();
			entity.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");

			List<BOStudio> response = mapper.MapEFToBO(new List<Studio>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>0ba82e98559d1c8e3f4c7b37633abf80</Hash>
</Codenesium>*/