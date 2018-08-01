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
	[Trait("Table", "LibraryVariableSet")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLLibraryVariableSetMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLLibraryVariableSetMapper();
			ApiLibraryVariableSetRequestModel model = new ApiLibraryVariableSetRequestModel();
			model.SetProperties("A", "A", "A", "A");
			BOLibraryVariableSet response = mapper.MapModelToBO("A", model);

			response.ContentType.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.VariableSetId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLLibraryVariableSetMapper();
			BOLibraryVariableSet bo = new BOLibraryVariableSet();
			bo.SetProperties("A", "A", "A", "A", "A");
			ApiLibraryVariableSetResponseModel response = mapper.MapBOToModel(bo);

			response.ContentType.Should().Be("A");
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.VariableSetId.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLLibraryVariableSetMapper();
			BOLibraryVariableSet bo = new BOLibraryVariableSet();
			bo.SetProperties("A", "A", "A", "A", "A");
			List<ApiLibraryVariableSetResponseModel> response = mapper.MapBOToModel(new List<BOLibraryVariableSet>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b60a79800be541646a1c94a69fbb261c</Hash>
</Codenesium>*/