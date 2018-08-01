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
	[Trait("Table", "MachinePolicy")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMachinePolicyMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMachinePolicyMapper();
			ApiMachinePolicyRequestModel model = new ApiMachinePolicyRequestModel();
			model.SetProperties(true, "A", "A");
			BOMachinePolicy response = mapper.MapModelToBO("A", model);

			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMachinePolicyMapper();
			BOMachinePolicy bo = new BOMachinePolicy();
			bo.SetProperties("A", true, "A", "A");
			ApiMachinePolicyResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be("A");
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMachinePolicyMapper();
			BOMachinePolicy bo = new BOMachinePolicy();
			bo.SetProperties("A", true, "A", "A");
			List<ApiMachinePolicyResponseModel> response = mapper.MapBOToModel(new List<BOMachinePolicy>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7003817f7aa9bb13739d90204af0883c</Hash>
</Codenesium>*/