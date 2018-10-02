using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStatus")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStatusModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusRequestModel();
			model.SetProperties("A");
			ApiEventStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusResponseModel();
			model.SetProperties(1, "A");
			ApiEventStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiEventStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>3764675760ce7d45be4b105bfdac68ae</Hash>
</Codenesium>*/