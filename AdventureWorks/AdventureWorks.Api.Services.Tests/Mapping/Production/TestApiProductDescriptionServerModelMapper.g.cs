using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ProductDescription")]
	[Trait("Area", "ApiModel")]
	public class TestApiProductDescriptionServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiProductDescriptionServerModelMapper();
			var model = new ApiProductDescriptionServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductDescriptionServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiProductDescriptionServerModelMapper();
			var model = new ApiProductDescriptionServerResponseModel();
			model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiProductDescriptionServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiProductDescriptionServerModelMapper();
			var model = new ApiProductDescriptionServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

			JsonPatchDocument<ApiProductDescriptionServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiProductDescriptionServerRequestModel();
			patch.ApplyTo(response);
			response.Description.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}
	}
}

/*<Codenesium>
    <Hash>8650ac3748cc65279157d7a44eec406d</Hash>
</Codenesium>*/