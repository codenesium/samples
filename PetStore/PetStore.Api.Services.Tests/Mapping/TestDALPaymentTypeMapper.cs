using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "DALMapper")]
	public class TestDALPaymentTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPaymentTypeMapper();
			ApiPaymentTypeServerRequestModel model = new ApiPaymentTypeServerRequestModel();
			model.SetProperties("A");
			PaymentType response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPaymentTypeMapper();
			PaymentType item = new PaymentType();
			item.SetProperties(1, "A");
			ApiPaymentTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPaymentTypeMapper();
			PaymentType item = new PaymentType();
			item.SetProperties(1, "A");
			List<ApiPaymentTypeServerResponseModel> response = mapper.MapEntityToModel(new List<PaymentType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e1ae6ad71f5805e5b8317971f11610a3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/