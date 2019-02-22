using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Officer")]
	[Trait("Area", "ApiModel")]
	public class TestApiOfficerServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiOfficerServerModelMapper();
			var model = new ApiOfficerServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			ApiOfficerServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiOfficerServerModelMapper();
			var model = new ApiOfficerServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A");
			ApiOfficerServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiOfficerServerModelMapper();
			var model = new ApiOfficerServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");

			JsonPatchDocument<ApiOfficerServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiOfficerServerRequestModel();
			patch.ApplyTo(response);
			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>3bf5b789cfb96cf8e1a26549efce5d2a</Hash>
</Codenesium>*/