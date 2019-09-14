using FluentAssertions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace NebulaNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Machine")]
	[Trait("Area", "DALMapper")]
	public class TestDALMachineMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALMachineMapper();
			ApiMachineServerRequestModel model = new ApiMachineServerRequestModel();
			model.SetProperties("A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			Machine response = mapper.MapModelToEntity(1, model);

			response.Description.Should().Be("A");
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALMachineMapper();
			Machine item = new Machine();
			item.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiMachineServerResponseModel response = mapper.MapEntityToModel(item);

			response.Description.Should().Be("A");
			response.Id.Should().Be(1);
			response.JwtKey.Should().Be("A");
			response.LastIpAddress.Should().Be("A");
			response.MachineGuid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALMachineMapper();
			Machine item = new Machine();
			item.SetProperties(1, "A", "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			List<ApiMachineServerResponseModel> response = mapper.MapEntityToModel(new List<Machine>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>68db80ec04c75120fb2bbbf4f2272e62</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/