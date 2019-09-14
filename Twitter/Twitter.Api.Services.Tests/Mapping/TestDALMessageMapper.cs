using FluentAssertions;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Message")]
	[Trait("Area", "DALMapper")]
	public class TestDALMessageMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALMessageMapper();
			ApiMessageServerRequestModel model = new ApiMessageServerRequestModel();
			model.SetProperties("A", 1);
			Message response = mapper.MapModelToEntity(1, model);

			response.Content.Should().Be("A");
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALMessageMapper();
			Message item = new Message();
			item.SetProperties(1, "A", 1);
			ApiMessageServerResponseModel response = mapper.MapEntityToModel(item);

			response.Content.Should().Be("A");
			response.MessageId.Should().Be(1);
			response.SenderUserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALMessageMapper();
			Message item = new Message();
			item.SetProperties(1, "A", 1);
			List<ApiMessageServerResponseModel> response = mapper.MapEntityToModel(new List<Message>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>310937b8121fd48b54e30c230ea91ffa</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/