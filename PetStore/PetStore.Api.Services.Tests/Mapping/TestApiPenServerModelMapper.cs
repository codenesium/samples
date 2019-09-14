using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Pen")]
	[Trait("Area", "ApiModel")]
	public class TestApiPenServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPenServerModelMapper();
			var model = new ApiPenServerRequestModel();
			model.SetProperties("A");
			ApiPenServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPenServerModelMapper();
			var model = new ApiPenServerResponseModel();
			model.SetProperties(1, "A");
			ApiPenServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPenServerModelMapper();
			var model = new ApiPenServerRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiPenServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPenServerRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>1d1088428ff704691d6387efff6db4f3</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/