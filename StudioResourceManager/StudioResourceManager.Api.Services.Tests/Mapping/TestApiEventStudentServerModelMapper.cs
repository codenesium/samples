using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
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
			model.SetProperties(1, 1);
			ApiEventStudentServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerResponseModel();
			model.SetProperties(1, 1, 1);
			ApiEventStudentServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiEventStudentServerModelMapper();
			var model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1, 1);

			JsonPatchDocument<ApiEventStudentServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiEventStudentServerRequestModel();
			patch.ApplyTo(response);
			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2a4582c1039e73e90952ec14ec2916cc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/