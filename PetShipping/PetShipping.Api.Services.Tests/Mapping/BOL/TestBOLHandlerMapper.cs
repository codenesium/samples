using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Handler")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLHandlerMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLHandlerMapper();
			ApiHandlerServerRequestModel model = new ApiHandlerServerRequestModel();
			model.SetProperties(1, "A", "A", "A", "A");
			BOHandler response = mapper.MapModelToBO(1, model);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLHandlerMapper();
			BOHandler bo = new BOHandler();
			bo.SetProperties(1, 1, "A", "A", "A", "A");
			ApiHandlerServerResponseModel response = mapper.MapBOToModel(bo);

			response.CountryId.Should().Be(1);
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLHandlerMapper();
			BOHandler bo = new BOHandler();
			bo.SetProperties(1, 1, "A", "A", "A", "A");
			List<ApiHandlerServerResponseModel> response = mapper.MapBOToModel(new List<BOHandler>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>95d6c17a8e1406e58af9b75ecc43a4db</Hash>
</Codenesium>*/