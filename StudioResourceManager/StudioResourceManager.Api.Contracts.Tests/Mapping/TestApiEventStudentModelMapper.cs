using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStudentModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentRequestModel();
			model.SetProperties(1, true);
			ApiEventStudentResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentResponseModel();
			model.SetProperties(1, 1, true);
			ApiEventStudentRequestModel response = mapper.MapResponseToRequest(model);

			response.StudentId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentRequestModel();
			model.SetProperties(1, true);

			JsonPatchDocument<ApiEventStudentRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStudentRequestModel();
			patch.ApplyTo(response);
			response.StudentId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>32f011b0d6cf31b8baecf2ac95a7b971</Hash>
</Codenesium>*/