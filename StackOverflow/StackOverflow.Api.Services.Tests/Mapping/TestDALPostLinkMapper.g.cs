using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostLink")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostLinkMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostLinkMapper();
			ApiPostLinkServerRequestModel model = new ApiPostLinkServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			PostLink response = mapper.MapModelToEntity(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostLinkMapper();
			PostLink item = new PostLink();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			ApiPostLinkServerResponseModel response = mapper.MapEntityToModel(item);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.LinkTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RelatedPostId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostLinkMapper();
			PostLink item = new PostLink();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, 1);
			List<ApiPostLinkServerResponseModel> response = mapper.MapEntityToModel(new List<PostLink>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9f13e6cd0b4c7b2d284f8bc3f62cff0f</Hash>
</Codenesium>*/