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
    <Hash>893227942228122741578e6e0de7f213</Hash>
</Codenesium>*/