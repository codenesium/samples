using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "ApiModel")]
	public class TestApiFileServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiFileServerModelMapper();
			var model = new ApiFileServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
			ApiFileServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1);
			response.FileTypeId.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiFileServerModelMapper();
			var model = new ApiFileServerResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
			ApiFileServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1);
			response.FileTypeId.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiFileServerModelMapper();
			var model = new ApiFileServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");

			JsonPatchDocument<ApiFileServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiFileServerRequestModel();
			patch.ApplyTo(response);
			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1);
			response.FileTypeId.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>2a652d89413ec32590109fbedad92a00</Hash>
</Codenesium>*/