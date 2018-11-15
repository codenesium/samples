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
	[Trait("Table", "Message")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLMessageMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLMessageMapper();
			ApiMessageServerRequestModel model = new ApiMessageServerRequestModel();
			model.SetProperties("A", 1);
			BOMessage response = mapper.MapModelToBO(1, model);

			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLMessageMapper();
			BOMessage bo = new BOMessage();
			bo.SetProperties(1, "A", 1);
			ApiMessageServerResponseModel response = mapper.MapBOToModel(bo);

			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLMessageMapper();
			BOMessage bo = new BOMessage();
			bo.SetProperties(1, "A", 1);
			List<ApiMessageServerResponseModel> response = mapper.MapBOToModel(new List<BOMessage>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>92b7918aa7320a696e1729f94850cbe0</Hash>
</Codenesium>*/