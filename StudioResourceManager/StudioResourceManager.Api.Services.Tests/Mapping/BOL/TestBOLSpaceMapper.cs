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
			model.SetProperties("A", "A", true);
			BOSpace response = mapper.MapModelToBO(1, model);

			response.Description.Should().Be("A");
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A", true);
			ApiSpaceResponseModel response = mapper.MapBOToModel(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLSpaceMapper();
			BOSpace bo = new BOSpace();
			bo.SetProperties(1, "A", "A", true);
			List<ApiSpaceResponseModel> response = mapper.MapBOToModel(new List<BOSpace>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e933cb07ec02f98f19007e4f7a303ffd</Hash>
</Codenesium>*/