using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Sale")]
	[Trait("Area", "DALMapper")]
	public class TestDALSaleMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSaleMapper();
			ApiSaleServerRequestModel model = new ApiSaleServerRequestModel();
			model.SetProperties(1m, "A", "A", 1, 1, "A");
			Sale response = mapper.MapModelToEntity(1, model);

			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1m, "A", "A", 1, 1, "A");
			ApiSaleServerResponseModel response = mapper.MapEntityToModel(item);

			response.Amount.Should().Be(1m);
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.PaymentTypeId.Should().Be(1);
			response.PetId.Should().Be(1);
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSaleMapper();
			Sale item = new Sale();
			item.SetProperties(1, 1m, "A", "A", 1, 1, "A");
			List<ApiSaleServerResponseModel> response = mapper.MapEntityToModel(new List<Sale>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7b49e2877a7bea42cd8e075c2fb66e73</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/