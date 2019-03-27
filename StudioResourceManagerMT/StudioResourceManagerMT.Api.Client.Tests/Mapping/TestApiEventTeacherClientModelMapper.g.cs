using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "ApiModel")]
	public class TestApiEventTeacherModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherClientRequestModel();
			model.SetProperties(1);
			ApiEventTeacherClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherClientResponseModel();
			model.SetProperties(1, 1);
			ApiEventTeacherClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.TeacherId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>3ae959179effea572c99ad3425c6dcfa</Hash>
</Codenesium>*/