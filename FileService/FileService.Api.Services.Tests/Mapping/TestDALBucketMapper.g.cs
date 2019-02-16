using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Bucket")]
	[Trait("Area", "DALMapper")]
	public class TestDALBucketMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALBucketMapper();
			ApiBucketServerRequestModel model = new ApiBucketServerRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			Bucket response = mapper.MapModelToEntity(1, model);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALBucketMapper();
			Bucket item = new Bucket();
			item.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketServerResponseModel response = mapper.MapEntityToModel(item);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALBucketMapper();
			Bucket item = new Bucket();
			item.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			List<ApiBucketServerResponseModel> response = mapper.MapEntityToModel(new List<Bucket>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>247f41f8c9bd9000a2698a0e5c764301</Hash>
</Codenesium>*/