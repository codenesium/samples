using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventStudentServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1);
			ApiEventStudentServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerResponseModel();
			model.SetProperties(1, 1);
			ApiEventStudentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiEventStudentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStudentServerRequestModel();
			patch.ApplyTo(response);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e9bb691ec7c8f6e5b290d200ed908b86</Hash>
</Codenesium>*/