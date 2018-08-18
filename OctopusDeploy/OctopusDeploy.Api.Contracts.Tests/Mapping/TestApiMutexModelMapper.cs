using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Mutex")]
	[Trait("Area", "ApiModel")]
	public class TestApiMutexModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiMutexModelMapper();
			var model = new ApiMutexRequestModel();
			model.SetProperties("A");
			ApiMutexResponseModel response = mapper.MapRequestToResponse("A", model);

			response.Id.Should().Be("A");
			response.JSON.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiMutexModelMapper();
			var model = new ApiMutexResponseModel();
			model.SetProperties("A", "A");
			ApiMutexRequestModel response = mapper.MapResponseToRequest(model);

			response.JSON.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiMutexModelMapper();
			var model = new ApiMutexRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiMutexRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiMutexRequestModel();
			patch.ApplyTo(response);
			response.JSON.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>479519c7fb1ce75cb8bbd2cfdce5b14f</Hash>
</Codenesium>*/