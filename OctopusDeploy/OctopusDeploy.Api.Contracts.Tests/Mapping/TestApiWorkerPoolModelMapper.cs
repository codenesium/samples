using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkerPool")]
	[Trait("Area", "ApiModel")]
	public class TestApiWorkerPoolModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiWorkerPoolModelMapper();
			var model = new ApiWorkerPoolRequestModel();
			model.SetProperties(true, "A", "A", 1);
			ApiWorkerPoolResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiWorkerPoolModelMapper();
			var model = new ApiWorkerPoolResponseModel();
			model.SetProperties("A", true, "A", "A", 1);
			ApiWorkerPoolRequestModel response = mapper.MapResponseToRequest(model);

			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiWorkerPoolModelMapper();
			var model = new ApiWorkerPoolRequestModel();
			model.SetProperties(true, "A", "A", 1);

			JsonPatchDocument<ApiWorkerPoolRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiWorkerPoolRequestModel();
			patch.ApplyTo(response);
			response.IsDefault.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.SortOrder.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>914630bc1bb7831aa59bb52ef251d2d7</Hash>
</Codenesium>*/