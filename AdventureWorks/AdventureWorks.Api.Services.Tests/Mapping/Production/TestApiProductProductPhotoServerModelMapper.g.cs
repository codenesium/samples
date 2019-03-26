using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductProductPhotoServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProductProductPhotoServerModelMapper();
			var model = new ApiProductProductPhotoServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProductProductPhotoServerModelMapper();
			var model = new ApiProductProductPhotoServerResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductProductPhotoServerModelMapper();
			var model = new ApiProductProductPhotoServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);

			JsonPatchDocument<ApiProductProductPhotoServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductProductPhotoServerRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>75aa12a65f7e1539911d573bfb358a28</Hash>
</Codenesium>*/