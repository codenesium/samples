using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallPerson")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallPersonServerModelMapper();
			var model = new ApiCallPersonServerRequestModel();
			model.SetProperties("A", 1, 1);
			ApiCallPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallPersonServerModelMapper();
			var model = new ApiCallPersonServerResponseModel();
			model.SetProperties(1, "A", 1, 1);
			ApiCallPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallPersonServerModelMapper();
			var model = new ApiCallPersonServerRequestModel();
			model.SetProperties("A", 1, 1);

			JsonPatchDocument<ApiCallPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallPersonServerRequestModel();
			patch.ApplyTo(response);
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c5cb758b924940300c94d231b8967a75</Hash>
</Codenesium>*/