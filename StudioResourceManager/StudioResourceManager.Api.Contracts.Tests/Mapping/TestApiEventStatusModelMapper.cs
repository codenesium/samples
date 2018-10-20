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
			model.SetProperties("A", true);
			ApiEventStatusResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusResponseModel();
			model.SetProperties(1, "A", true);
			ApiEventStatusRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStatusModelMapper();
			var model = new ApiEventStatusRequestModel();
			model.SetProperties("A", true);

			JsonPatchDocument<ApiEventStatusRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStatusRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>4d00a813a6ada8ad50bd56d2d4c14270</Hash>
</Codenesium>*/