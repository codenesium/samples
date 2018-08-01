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
	[Trait("Table", "Bucket")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLBucketMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLBucketMapper();
			ApiBucketRequestModel model = new ApiBucketRequestModel();
			model.SetProperties(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			BOBucket response = mapper.MapModelToBO(1, model);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLBucketMapper();
			BOBucket bo = new BOBucket();
			bo.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			ApiBucketResponseModel response = mapper.MapBOToModel(bo);

			response.ExternalId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLBucketMapper();
			BOBucket bo = new BOBucket();
			bo.SetProperties(1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A");
			List<ApiBucketResponseModel> response = mapper.MapBOToModel(new List<BOBucket>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>159e73ad55c8e5826e026fc04e65a96e</Hash>
</Codenesium>*/