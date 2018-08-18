using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services.Tests
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
			model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			BOMachine response = mapper.MapModelToBO(1, model);

			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMachineMapper();
			BOMachine bo = new BOMachine();
			bo.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineResponseModel response = mapper.MapBOToModel(bo);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMachineMapper();
			BOMachine bo = new BOMachine();
			bo.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			List<ApiMachineResponseModel> response = mapper.MapBOToModel(new List<BOMachine>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>11f30d06146f4da385c283a3fc62c2dc</Hash>
</Codenesium>*/