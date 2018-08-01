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
	[Trait("Table", "Machine")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMachineMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMachineMapper();
			ApiMachineRequestModel model = new ApiMachineRequestModel();
			model.SetProperties("A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
			BOMachine response = mapper.MapModelToBO("A", model);

			response.CommunicationStyle.Should().Be("A");
			response.EnvironmentIds.Should().Be("A");
			response.Fingerprint.Should().Be("A");
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.MachinePolicyId.Should().Be("A");
			response.Name.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Roles.Should().Be("A");
			response.TenantIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
			response.Thumbprint.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMachineMapper();
			BOMachine bo = new BOMachine();
			bo.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
			ApiMachineResponseModel response = mapper.MapBOToModel(bo);

			response.CommunicationStyle.Should().Be("A");
			response.EnvironmentIds.Should().Be("A");
			response.Fingerprint.Should().Be("A");
			response.Id.Should().Be("A");
			response.IsDisabled.Should().Be(true);
			response.JSON.Should().Be("A");
			response.MachinePolicyId.Should().Be("A");
			response.Name.Should().Be("A");
			response.RelatedDocumentIds.Should().Be("A");
			response.Roles.Should().Be("A");
			response.TenantIds.Should().Be("A");
			response.TenantTags.Should().Be("A");
			response.Thumbprint.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMachineMapper();
			BOMachine bo = new BOMachine();
			bo.SetProperties("A", "A", "A", "A", true, "A", "A", "A", "A", "A", "A", "A", "A");
			List<ApiMachineResponseModel> response = mapper.MapBOToModel(new List<BOMachine>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>54f75313547bf606c9f8700b84143f85</Hash>
</Codenesium>*/