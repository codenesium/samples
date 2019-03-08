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
    <Hash>345416decde333cc0e9fd9a26a386dba</Hash>
</Codenesium>*/