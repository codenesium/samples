using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "BusinessEntityContact")]
	[Trait("Area", "DALMapper")]
	public class TestDALBusinessEntityContactMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALBusinessEntityContactMapper();
			var bo = new BOBusinessEntityContact();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			BusinessEntityContact response = mapper.MapBOToEF(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ContactTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALBusinessEntityContactMapper();
			BusinessEntityContact entity = new BusinessEntityContact();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			BOBusinessEntityContact response = mapper.MapEFToBO(entity);

			response.BusinessEntityID.Should().Be(1);
			response.ContactTypeID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PersonID.Should().Be(1);
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALBusinessEntityContactMapper();
			BusinessEntityContact entity = new BusinessEntityContact();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			List<BOBusinessEntityContact> response = mapper.MapEFToBO(new List<BusinessEntityContact>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ec1c412cab4c4847ea94641b9811d9b</Hash>
</Codenesium>*/