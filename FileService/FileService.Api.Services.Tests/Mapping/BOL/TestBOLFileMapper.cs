using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FileServiceNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLFileMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLFileMapper();
			ApiFileRequestModel model = new ApiFileRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			BOFile response = mapper.MapModelToBO(1, model);

			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInBytes.Should().Be(1m);
			response.FileTypeId.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLFileMapper();
			BOFile bo = new BOFile();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			ApiFileResponseModel response = mapper.MapBOToModel(bo);

			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInBytes.Should().Be(1m);
			response.FileTypeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLFileMapper();
			BOFile bo = new BOFile();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			List<ApiFileResponseModel> response = mapper.MapBOToModel(new List<BOFile>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>fab2e9db29fcb705575eb97951513ab8</Hash>
</Codenesium>*/