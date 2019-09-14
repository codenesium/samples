using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Comment")]
	[Trait("Area", "DALMapper")]
	public class TestDALCommentMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCommentMapper();
			ApiCommentServerRequestModel model = new ApiCommentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			Comment response = mapper.MapModelToEntity(1, model);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCommentMapper();
			Comment item = new Comment();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			ApiCommentServerResponseModel response = mapper.MapEntityToModel(item);

			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostId.Should().Be(1);
			response.Score.Should().Be(1);
			response.Text.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCommentMapper();
			Comment item = new Comment();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", 1);
			List<ApiCommentServerResponseModel> response = mapper.MapEntityToModel(new List<Comment>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>7ae284d671221dbabd77c63c0445ca09</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/