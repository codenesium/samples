using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductProductPhotoModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiProductProductPhotoModelMapper();
			var model = new ApiProductProductPhotoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoResponseModel response = mapper.MapRequestToResponse(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductID.Should().Be(1);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiProductProductPhotoModelMapper();
			var model = new ApiProductProductPhotoResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoRequestModel response = mapper.MapResponseToRequest(model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductProductPhotoModelMapper();
			var model = new ApiProductProductPhotoRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);

			JsonPatchDocument<ApiProductProductPhotoRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductProductPhotoRequestModel();
			patch.ApplyTo(response);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2f9e1b50bef6e2d8de3c16bfb03c629a</Hash>
</Codenesium>*/