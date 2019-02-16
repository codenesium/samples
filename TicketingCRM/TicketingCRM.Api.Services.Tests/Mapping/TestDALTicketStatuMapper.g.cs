using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTicketStatuMapper();
			ApiTicketStatuServerRequestModel model = new ApiTicketStatuServerRequestModel();
			model.SetProperties("A");
			TicketStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTicketStatuMapper();
			TicketStatu item = new TicketStatu();
			item.SetProperties(1, "A");
			ApiTicketStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTicketStatuMapper();
			TicketStatu item = new TicketStatu();
			item.SetProperties(1, "A");
			List<ApiTicketStatuServerResponseModel> response = mapper.MapEntityToModel(new List<TicketStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>bf0b1be9016068aa94e98563c115178c</Hash>
</Codenesium>*/