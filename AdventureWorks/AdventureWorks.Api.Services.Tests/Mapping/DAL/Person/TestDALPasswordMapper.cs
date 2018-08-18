using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Password")]
	[Trait("Area", "DALMapper")]
	public class TestDALPasswordMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPasswordMapper();
			var bo = new BOPassword();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			Password response = mapper.MapBOToEF(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PasswordHash.Should().Be("A");
			response.PasswordSalt.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPasswordMapper();
			Password entity = new Password();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			BOPassword response = mapper.MapEFToBO(entity);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PasswordHash.Should().Be("A");
			response.PasswordSalt.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPasswordMapper();
			Password entity = new Password();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			List<BOPassword> response = mapper.MapEFToBO(new List<Password>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>12586df16a6eb00ac7069802f01304d8</Hash>
</Codenesium>*/