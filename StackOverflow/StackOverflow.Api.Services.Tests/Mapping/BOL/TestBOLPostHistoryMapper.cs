using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PostHistory")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPostHistoryMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPostHistoryMapper();
			ApiPostHistoryServerRequestModel model = new ApiPostHistoryServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			BOPostHistory response = mapper.MapModelToBO(1, model);

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
		public void MapBOToModel()
		{
			var mapper = new BOLPostHistoryMapper();
			BOPostHistory bo = new BOPostHistory();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			ApiPostHistoryServerResponseModel response = mapper.MapBOToModel(bo);

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
		public void MapBOToModelList()
		{
			var mapper = new BOLPostHistoryMapper();
			BOPostHistory bo = new BOPostHistory();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A", "A", "A", 1);
			List<ApiPostHistoryServerResponseModel> response = mapper.MapBOToModel(new List<BOPostHistory>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ac1b831a9991fd099ee86ffdbe4ae489</Hash>
</Codenesium>*/