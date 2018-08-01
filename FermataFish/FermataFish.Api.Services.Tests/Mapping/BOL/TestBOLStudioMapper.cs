using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLStudioMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLStudioMapper();
			ApiStudioRequestModel model = new ApiStudioRequestModel();
			model.SetProperties("A", "A", "A", "A", 1, "A", "A");
			BOStudio response = mapper.MapModelToBO(1, model);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.StateId.Should().Be(1);
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", 1, "A", "A");
			ApiStudioResponseModel response = mapper.MapBOToModel(bo);

			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StateId.Should().Be(1);
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLStudioMapper();
			BOStudio bo = new BOStudio();
			bo.SetProperties(1, "A", "A", "A", "A", 1, "A", "A");
			List<ApiStudioResponseModel> response = mapper.MapBOToModel(new List<BOStudio>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>aa5117dbb6306c9d05946f81c06ca38d</Hash>
</Codenesium>*/