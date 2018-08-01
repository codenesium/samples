using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Ticket")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTicketMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTicketMapper();
			ApiTicketRequestModel model = new ApiTicketRequestModel();
			model.SetProperties("A", 1);
			BOTicket response = mapper.MapModelToBO(1, model);

			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTicketMapper();
			BOTicket bo = new BOTicket();
			bo.SetProperties(1, "A", 1);
			ApiTicketResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.PublicId.Should().Be("A");
			response.TicketStatusId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTicketMapper();
			BOTicket bo = new BOTicket();
			bo.SetProperties(1, "A", 1);
			List<ApiTicketResponseModel> response = mapper.MapBOToModel(new List<BOTicket>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>52548835c116aff34b6678b0c144ab41</Hash>
</Codenesium>*/