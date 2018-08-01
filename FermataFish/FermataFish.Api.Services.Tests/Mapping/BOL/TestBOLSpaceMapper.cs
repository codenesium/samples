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
	[Trait("Table", "Space")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLSpaceMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLSpaceMapper();
			ApiSpaceRequestModel model = new ApiSpaceRequestModel();
			model.SetProperties("A", "A", 1);
			BOSpace response = mapper.MapModelToBO(1, model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A", 1);
			ApiSpaceResponseModel response = mapper.MapBOToModel(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StudioId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A", 1);
			List<ApiSpaceResponseModel> response = mapper.MapBOToModel(new List<BOSpace>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cec9dc41155dff6ad40b2ae985a6faee</Hash>
</Codenesium>*/