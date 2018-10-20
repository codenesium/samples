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
			model.SetProperties(1, true);
			ApiEventTeacherResponseModel response = mapper.MapRequestToResponse(1, model);

			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherResponseModel();
			model.SetProperties(1, 1, true);
			ApiEventTeacherRequestModel response = mapper.MapResponseToRequest(model);

			response.TeacherId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherRequestModel();
			model.SetProperties(1, true);

			JsonPatchDocument<ApiEventTeacherRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventTeacherRequestModel();
			patch.ApplyTo(response);
			response.TeacherId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}
	}
}

/*<Codenesium>
    <Hash>2c05a3ff66f2564ccfee18be1be8a4e1</Hash>
</Codenesium>*/