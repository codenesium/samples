using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PaymentType")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPaymentTypeMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPaymentTypeMapper();
			ApiPaymentTypeServerRequestModel model = new ApiPaymentTypeServerRequestModel();
			model.SetProperties("A");
			BOPaymentType response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPaymentTypeMapper();
			BOPaymentType bo = new BOPaymentType();
			bo.SetProperties(1, "A");
			ApiPaymentTypeServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPaymentTypeMapper();
			BOPaymentType bo = new BOPaymentType();
			bo.SetProperties(1, "A");
			List<ApiPaymentTypeServerResponseModel> response = mapper.MapBOToModel(new List<BOPaymentType>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>03be66dd107cab18e22d9e40fc8a9976</Hash>
</Codenesium>*/