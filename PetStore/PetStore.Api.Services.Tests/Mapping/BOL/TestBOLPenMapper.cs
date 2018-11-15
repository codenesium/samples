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
	[Trait("Table", "Pen")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPenMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPenMapper();
			ApiPenServerRequestModel model = new ApiPenServerRequestModel();
			model.SetProperties("A");
			BOPen response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPenMapper();
			BOPen bo = new BOPen();
			bo.SetProperties(1, "A");
			ApiPenServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPenMapper();
			BOPen bo = new BOPen();
			bo.SetProperties(1, "A");
			List<ApiPenServerResponseModel> response = mapper.MapBOToModel(new List<BOPen>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>95e18ff06f1932c280fa9677b2215278</Hash>
</Codenesium>*/