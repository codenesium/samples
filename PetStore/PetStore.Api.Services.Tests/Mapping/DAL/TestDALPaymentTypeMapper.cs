using FluentAssertions;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPaymentTypeMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPaymentTypeMapper();
			var bo = new BOPaymentType();
			bo.SetProperties(1, "A");

			PaymentType response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPaymentTypeMapper();
			PaymentType entity = new PaymentType();
			entity.SetProperties(1, "A");

			BOPaymentType response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPaymentTypeMapper();
			PaymentType entity = new PaymentType();
			entity.SetProperties(1, "A");

			List<BOPaymentType> response = mapper.MapEFToBO(new List<PaymentType>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5b3b9c759e0b2d8de725c23aceae9f82</Hash>
</Codenesium>*/