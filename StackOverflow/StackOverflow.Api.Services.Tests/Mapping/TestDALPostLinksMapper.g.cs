using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostLinks")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostLinksMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostLinksMapper();
			ApiPostLinksServerRequestModel model = new ApiPostLinksServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			PostLinks response = mapper.MapModelToEntity(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostLinksMapper();
			PostLinks item = new PostLinks();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinksServerResponseModel response = mapper.MapEntityToModel(item);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostLinksMapper();
			PostLinks item = new PostLinks();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			List<ApiPostLinksServerResponseModel> response = mapper.MapEntityToModel(new List<PostLinks>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9cd5ed6c93b42d873b5f0b4c5feff90a</Hash>
</Codenesium>*/