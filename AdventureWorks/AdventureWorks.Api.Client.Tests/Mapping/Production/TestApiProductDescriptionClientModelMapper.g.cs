using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductDescriptionModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiProductDescriptionModelMapper();
			var model = new ApiProductDescriptionClientRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductDescriptionClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiProductDescriptionModelMapper();
			var model = new ApiProductDescriptionClientResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductDescriptionClientRequestModel response = mapper.MapClientResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>cb9e6d52cfbb9c1579a8024f38736212</Hash>
</Codenesium>*/