using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "ApiModel")]
	public class TestApiRateServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiRateServerModelMapper();
			var model = new ApiRateServerRequestModel();
			model.SetProperties(1m, 1, 1);
			ApiRateServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiRateServerModelMapper();
			var model = new ApiRateServerResponseModel();
			model.SetProperties(1, 1m, 1, 1);
			ApiRateServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiRateServerModelMapper();
			var model = new ApiRateServerRequestModel();
			model.SetProperties(1m, 1, 1);

			JsonPatchDocument<ApiRateServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiRateServerRequestModel();
			patch.ApplyTo(response);
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>26511b662d25007230248a7960c91736</Hash>
</Codenesium>*/