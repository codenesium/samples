using FluentAssertions;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALSaleMapper();
			var bo = new BOSale();
			bo.SetProperties(1, 1m, "A", "A", 1, 1, "A");

			Sale response = mapper.MapBOToEF(bo);

			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALSaleMapper();
			Sale entity = new Sale();
			entity.SetProperties(1m, "A", 1, "A", 1, 1, "A");

			BOSale response = mapper.MapEFToBO(entity);

			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALSaleMapper();
			Sale entity = new Sale();
			entity.SetProperties(1m, "A", 1, "A", 1, 1, "A");

			List<BOSale> response = mapper.MapEFToBO(new List<Sale>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>66a1a85cf9db2676e90fb412744a05e1</Hash>
</Codenesium>*/