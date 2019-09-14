using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "File")]
	[Trait("Area", "DALMapper")]
	public class TestDALFileMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALFileMapper();
			ApiFileServerRequestModel model = new ApiFileServerRequestModel();
			model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			File response = mapper.MapModelToEntity(1, model);

			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1m);
			response.FileTypeId.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALFileMapper();
			File item = new File();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			ApiFileServerResponseModel response = mapper.MapEntityToModel(item);

			response.BucketId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Description.Should().Be("A");
			response.Expiration.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Extension.Should().Be("A");
			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.FileSizeInByte.Should().Be(1m);
			response.FileTypeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Location.Should().Be("A");
			response.PrivateKey.Should().Be("A");
			response.PublicKey.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALFileMapper();
			File item = new File();
			item.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1m, 1, "A", "A", "A");
			List<ApiFileServerResponseModel> response = mapper.MapEntityToModel(new List<File>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>52142794e3dce523f5bdfefef1fa3d60</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/