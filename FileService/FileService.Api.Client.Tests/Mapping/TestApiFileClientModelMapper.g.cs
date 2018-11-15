using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "ApiModel")]
	public class TestApiFileModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiFileModelMapper();
			var model = new ApiFileClientRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
			ApiFileClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiFileModelMapper();
			var model = new ApiFileClientResponseModel();
			model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1, "A", "A", "A");
			ApiFileClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>ad4003016d6b0e38a0187d2b568e0f3b</Hash>
</Codenesium>*/