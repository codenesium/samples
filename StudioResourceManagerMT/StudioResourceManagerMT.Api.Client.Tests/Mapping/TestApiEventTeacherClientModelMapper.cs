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
			model.SetProperties(1, 1);
			ApiEventTeacherClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiEventTeacherModelMapper();
			var model = new ApiEventTeacherClientResponseModel();
			model.SetProperties(1, 1, 1);
			ApiEventTeacherClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7803df6ae6b64aa1c7228e68a9504f52</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/