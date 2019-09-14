using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallDisposition")]
	[Trait("Area", "ApiModel")]
	public class TestApiCallDispositionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiCallDispositionServerModelMapper();
			var model = new ApiCallDispositionServerRequestModel();
			model.SetProperties("A");
			ApiCallDispositionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiCallDispositionServerModelMapper();
			var model = new ApiCallDispositionServerResponseModel();
			model.SetProperties(1, "A");
			ApiCallDispositionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiCallDispositionServerModelMapper();
			var model = new ApiCallDispositionServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiCallDispositionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiCallDispositionServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7e78d06f2cdd714e608cc1ad0d6938b2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/