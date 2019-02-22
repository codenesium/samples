using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", "A", "A");
			ApiPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A");
			ApiPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", "A", "A");

			JsonPatchDocument<ApiPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonServerRequestModel();
			patch.ApplyTo(response);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Ssn.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>4c4d9d928e83c852ca0b71c11b00b64e</Hash>
</Codenesium>*/