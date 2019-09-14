using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALPostHistoryMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPostHistoryMapper();
			ApiPostHistoryServerRequestModel model = new ApiPostHistoryServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			PostHistory response = mapper.MapModelToEntity(1, model);

			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPostHistoryMapper();
			PostHistory item = new PostHistory();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryServerResponseModel response = mapper.MapEntityToModel(item);

			response.Comment.Should().Be("A");
			response.CreationDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Id.Should().Be(1);
			response.PostHistoryTypeId.Should().Be(1);
			response.PostId.Should().Be(1);
			response.RevisionGUID.Should().Be("A");
			response.Text.Should().Be("A");
			response.UserDisplayName.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPostHistoryMapper();
			PostHistory item = new PostHistory();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			List<ApiPostHistoryServerResponseModel> response = mapper.MapEntityToModel(new List<PostHistory>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4b8f62b3503608a852326c7d3a4d04fc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/