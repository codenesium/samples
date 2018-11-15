using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using TwitterNS.Api.Services;
using Xunit;

namespace TwitterNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Messenger")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMessengerMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMessengerMapper();
			ApiMessengerServerRequestModel model = new ApiMessengerServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			BOMessenger response = mapper.MapModelToBO(1, model);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMessengerMapper();
			BOMessenger bo = new BOMessenger();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			ApiMessengerServerResponseModel response = mapper.MapBOToModel(bo);

			response.Date.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.FromUserId.Should().Be(1);
			response.Id.Should().Be(1);
			response.MessageId.Should().Be(1);
			response.Time.Should().Be(TimeSpan.Parse("01:00:00"));
			response.ToUserId.Should().Be(1);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMessengerMapper();
			BOMessenger bo = new BOMessenger();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, TimeSpan.Parse("01:00:00"), 1, 1);
			List<ApiMessengerServerResponseModel> response = mapper.MapBOToModel(new List<BOMessenger>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>64a0824c5ea4492de6d2da48443862a5</Hash>
</Codenesium>*/