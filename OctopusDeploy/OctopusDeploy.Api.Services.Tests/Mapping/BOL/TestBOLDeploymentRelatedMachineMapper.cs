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
	[Trait("Table", "DeploymentRelatedMachine")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLDeploymentRelatedMachineMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDeploymentRelatedMachineMapper();
			ApiDeploymentRelatedMachineRequestModel model = new ApiDeploymentRelatedMachineRequestModel();
			model.SetProperties("A", "A");
			BODeploymentRelatedMachine response = mapper.MapModelToBO(1, model);

			response.DeploymentId.Should().Be("A");
			response.MachineId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDeploymentRelatedMachineMapper();
			BODeploymentRelatedMachine bo = new BODeploymentRelatedMachine();
			bo.SetProperties(1, "A", "A");
			ApiDeploymentRelatedMachineResponseModel response = mapper.MapBOToModel(bo);

			response.DeploymentId.Should().Be("A");
			response.Id.Should().Be(1);
			response.MachineId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDeploymentRelatedMachineMapper();
			BODeploymentRelatedMachine bo = new BODeploymentRelatedMachine();
			bo.SetProperties(1, "A", "A");
			List<ApiDeploymentRelatedMachineResponseModel> response = mapper.MapBOToModel(new List<BODeploymentRelatedMachine>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9b435e85c8037171a97c7bc8f2c9bfe8</Hash>
</Codenesium>*/