using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Studio")]
	[Trait("Area", "ApiModel")]
	public class TestApiStudioServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiStudioServerModelMapper();
			var model = new ApiStudioServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");
			ApiStudioServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiStudioServerModelMapper();
			var model = new ApiStudioServerResponseModel();
			model.SetProperties(1, "A", "A", "A", "A", "A", "A", "A");
			ApiStudioServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiStudioServerModelMapper();
			var model = new ApiStudioServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A", "A");

			JsonPatchDocument<ApiStudioServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiStudioServerRequestModel();
			patch.ApplyTo(response);
			response.Address1.Should().Be("A");
			response.Address2.Should().Be("A");
			response.City.Should().Be("A");
			response.Name.Should().Be("A");
			response.Province.Should().Be("A");
			response.Website.Should().Be("A");
			response.Zip.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>0a50d9d6629f037807b8fca88acfb9a4</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/