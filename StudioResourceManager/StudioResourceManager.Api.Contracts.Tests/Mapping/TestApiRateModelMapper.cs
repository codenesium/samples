using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using StudioResourceManagerNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "ApiModel")]
	public class TestApiRateModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiRateModelMapper();
			var model = new ApiRateRequestModel();
			model.SetProperties(1m, 1, 1);
			ApiRateResponseModel response = mapper.MapRequestToResponse(1, model);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiRateModelMapper();
			var model = new ApiRateResponseModel();
			model.SetProperties(1, 1m, 1, 1);
			ApiRateRequestModel response = mapper.MapResponseToRequest(model);

			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiRateModelMapper();
			var model = new ApiRateRequestModel();
			model.SetProperties(1m, 1, 1);

			JsonPatchDocument<ApiRateRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiRateRequestModel();
			patch.ApplyTo(response);
			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6575b02a437cab135b4291801f1d0834</Hash>
</Codenesium>*/