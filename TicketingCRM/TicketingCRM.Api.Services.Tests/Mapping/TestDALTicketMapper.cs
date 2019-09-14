using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTicketMapper();
			ApiTicketServerRequestModel model = new ApiTicketServerRequestModel();
			model.SetProperties("A", 1);
			Ticket response = mapper.MapModelToEntity(1, model);

			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTicketMapper();
			Ticket item = new Ticket();
			item.SetProperties(1, "A", 1);
			ApiTicketServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTicketMapper();
			Ticket item = new Ticket();
			item.SetProperties(1, "A", 1);
			List<ApiTicketServerResponseModel> response = mapper.MapEntityToModel(new List<Ticket>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ccdf0e93c2fa12da5f35bc1b053bd6a2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/