using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "WorkerTaskLease")]
	[Trait("Area", "ApiModel")]
	public class TestApiWorkerTaskLeaseModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiWorkerTaskLeaseModelMapper();
			var model = new ApiWorkerTaskLeaseRequestModel();
			model.SetProperties(true, "A", "A", "A", "A");
			ApiWorkerTaskLeaseResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Exclusive.Should().Be(true);
			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TaskId.Should().Be("A");
			response.WorkerId.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiWorkerTaskLeaseModelMapper();
			var model = new ApiWorkerTaskLeaseResponseModel();
			model.SetProperties("A", true, "A", "A", "A", "A");
			ApiWorkerTaskLeaseRequestModel response = mapper.MapResponseToRequest(model);

			response.Exclusive.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TaskId.Should().Be("A");
			response.WorkerId.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiWorkerTaskLeaseModelMapper();
			var model = new ApiWorkerTaskLeaseRequestModel();
			model.SetProperties(true, "A", "A", "A", "A");

			JsonPatchDocument<ApiWorkerTaskLeaseRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiWorkerTaskLeaseRequestModel();
			patch.ApplyTo(response);
			response.Exclusive.Should().Be(true);
			response.JSON.Should().Be("A");
			response.Name.Should().Be("A");
			response.TaskId.Should().Be("A");
			response.WorkerId.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1fe176b3d453b47f6396d11bdbb757d6</Hash>
</Codenesium>*/