using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Reply")]
	[Trait("Area", "DALMapper")]
	public class TestDALReplyMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALReplyMapper();
			ApiReplyServerRequestModel model = new ApiReplyServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			Reply response = mapper.MapModelToEntity(1, model);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALReplyMapper();
			Reply item = new Reply();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			ApiReplyServerResponseModel response = mapper.MapEntityToModel(item);

			response.Content.Should().Be("A");
			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ReplierUserId.Should().Be(1);
			response.ReplyId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALReplyMapper();
			Reply item = new Reply();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, TimeSpan.Parse("01:00:00"));
			List<ApiReplyServerResponseModel> response = mapper.MapEntityToModel(new List<Reply>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>abab6f7b19c04fbd1ed560a0223fd58a</Hash>
</Codenesium>*/