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
	[Trait("Table", "DeploymentProcess")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDeploymentProcessMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDeploymentProcessMapper();
			ApiDeploymentProcessRequestModel model = new ApiDeploymentProcessRequestModel();
			model.SetProperties(true, "A", "A", "A", 1);
			BODeploymentProcess response = mapper.MapModelToBO("A", model);

			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDeploymentProcessMapper();
			BODeploymentProcess bo = new BODeploymentProcess();
			bo.SetProperties("A", true, "A", "A", "A", 1);
			ApiDeploymentProcessResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be("A");
			response.IsFrozen.Should().Be(true);
			response.JSON.Should().Be("A");
			response.OwnerId.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Version.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDeploymentProcessMapper();
			BODeploymentProcess bo = new BODeploymentProcess();
			bo.SetProperties("A", true, "A", "A", "A", 1);
			List<ApiDeploymentProcessResponseModel> response = mapper.MapBOToModel(new List<BODeploymentProcess>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7cf24e13b9b3e488aca2b109d113e483</Hash>
</Codenesium>*/