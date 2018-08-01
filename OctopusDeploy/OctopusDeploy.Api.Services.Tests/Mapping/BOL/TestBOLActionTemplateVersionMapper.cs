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
	[Trait("Table", "ActionTemplateVersion")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLActionTemplateVersionMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLActionTemplateVersionMapper();
			ApiActionTemplateVersionRequestModel model = new ApiActionTemplateVersionRequestModel();
			model.SetProperties("A", "A", "A", "A", 1);
			BOActionTemplateVersion response = mapper.MapModelToBO("A", model);

			response.ActionType.Should().Be("A");
			response.JSON.Should().Be("A");
			response.LatestActionTemplateId.Should().Be("A");
			response.Name.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLActionTemplateVersionMapper();
			BOActionTemplateVersion bo = new BOActionTemplateVersion();
			bo.SetProperties("A", "A", "A", "A", "A", 1);
			ApiActionTemplateVersionResponseModel response = mapper.MapBOToModel(bo);

			response.ActionType.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.LatestActionTemplateId.Should().Be("A");
			response.Name.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLActionTemplateVersionMapper();
			BOActionTemplateVersion bo = new BOActionTemplateVersion();
			bo.SetProperties("A", "A", "A", "A", "A", 1);
			List<ApiActionTemplateVersionResponseModel> response = mapper.MapBOToModel(new List<BOActionTemplateVersion>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a017e8a3d20a224471ae59381f195121</Hash>
</Codenesium>*/