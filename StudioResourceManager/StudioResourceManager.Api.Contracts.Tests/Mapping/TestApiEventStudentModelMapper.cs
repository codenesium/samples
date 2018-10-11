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
			model.SetProperties(1);
			ApiEventStudentResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentResponseModel();
			model.SetProperties(1, 1);
			ApiEventStudentRequestModel response = mapper.MapResponseToRequest(model);

			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStudentModelMapper();
			var model = new ApiEventStudentRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiEventStudentRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStudentRequestModel();
			patch.ApplyTo(response);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6d7494f23c493251f82d4c338d8cf318</Hash>
</Codenesium>*/