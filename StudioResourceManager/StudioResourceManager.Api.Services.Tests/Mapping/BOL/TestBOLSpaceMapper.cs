using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
			model.SetProperties("A", "A");
			BOSpace response = mapper.MapModelToBO(1, model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A");
			ApiSpaceResponseModel response = mapper.MapBOToModel(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A");
			List<ApiSpaceResponseModel> response = mapper.MapBOToModel(new List<BOSpace>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>40200f20e30f48d6213d583f347c7fd3</Hash>
</Codenesium>*/