using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
			ApiSpaceServerRequestModel model = new ApiSpaceServerRequestModel();
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
			ApiSpaceServerResponseModel response = mapper.MapBOToModel(bo);

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
			List<ApiSpaceServerResponseModel> response = mapper.MapBOToModel(new List<BOSpace>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>cbb8840ee365cd3d0ffcfe598dcb1d0b</Hash>
</Codenesium>*/