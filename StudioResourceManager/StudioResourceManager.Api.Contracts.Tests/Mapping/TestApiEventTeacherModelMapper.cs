using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventTeacherModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherRequestModel();
			model.SetProperties(1);
			ApiEventTeacherResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EventId.Should().Be(1);
			response.Id.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherResponseModel();
			model.SetProperties(1, 1);
			ApiEventTeacherRequestModel response = mapper.MapResponseToRequest(model);

			response.EventId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherRequestModel();
			model.SetProperties(1);

			JsonPatchDocument<ApiEventTeacherRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventTeacherRequestModel();
			patch.ApplyTo(response);
			response.EventId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b9b956140a641580d202552d347fcb9b</Hash>
</Codenesium>*/