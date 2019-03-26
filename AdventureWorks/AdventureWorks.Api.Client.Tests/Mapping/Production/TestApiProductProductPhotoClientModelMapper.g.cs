using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductProductPhoto")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductProductPhotoModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductProductPhotoModelMapper();
			var model = new ApiProductProductPhotoClientRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductProductPhotoModelMapper();
			var model = new ApiProductProductPhotoClientResponseModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
			ApiProductProductPhotoClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Primary.Should().Be(true);
			response.ProductPhotoID.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>685b85b4aec3e95778121ec2d2f986dc</Hash>
</Codenesium>*/