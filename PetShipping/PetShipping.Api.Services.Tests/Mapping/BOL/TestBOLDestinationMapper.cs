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
	[Trait("Table", "Destination")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDestinationMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDestinationMapper();
			ApiDestinationServerRequestModel model = new ApiDestinationServerRequestModel();
			model.SetProperties(1, "A", 1);
			BODestination response = mapper.MapModelToBO(1, model);

			response.CountryId.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDestinationMapper();
			BODestination bo = new BODestination();
			bo.SetProperties(1, 1, "A", 1);
			ApiDestinationServerResponseModel response = mapper.MapBOToModel(bo);

			response.CountryId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Order.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDestinationMapper();
			BODestination bo = new BODestination();
			bo.SetProperties(1, 1, "A", 1);
			List<ApiDestinationServerResponseModel> response = mapper.MapBOToModel(new List<BODestination>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>8f75af74e20fe9034d19026bde7afc74</Hash>
</Codenesium>*/