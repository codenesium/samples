using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProjectGroup")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLProjectGroupMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLProjectGroupMapper();
			ApiProjectGroupRequestModel model = new ApiProjectGroupRequestModel();
			model.SetProperties(BitConverter.GetBytes(1), "A", "A");
			BOProjectGroup response = mapper.MapModelToBO("A", model);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLProjectGroupMapper();
			BOProjectGroup bo = new BOProjectGroup();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
			ApiProjectGroupResponseModel response = mapper.MapBOToModel(bo);

			response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLProjectGroupMapper();
			BOProjectGroup bo = new BOProjectGroup();
			bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
			List<ApiProjectGroupResponseModel> response = mapper.MapBOToModel(new List<BOProjectGroup>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>18c69e05ed4d8ac6ec7e5a93085d287b</Hash>
</Codenesium>*/