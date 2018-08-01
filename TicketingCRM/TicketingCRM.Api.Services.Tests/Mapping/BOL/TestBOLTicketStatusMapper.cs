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
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTicketStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTicketStatusMapper();
			ApiTicketStatusRequestModel model = new ApiTicketStatusRequestModel();
			model.SetProperties("A");
			BOTicketStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTicketStatusMapper();
			BOTicketStatus bo = new BOTicketStatus();
			bo.SetProperties(1, "A");
			ApiTicketStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTicketStatusMapper();
			BOTicketStatus bo = new BOTicketStatus();
			bo.SetProperties(1, "A");
			List<ApiTicketStatusResponseModel> response = mapper.MapBOToModel(new List<BOTicketStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5f5d84f4f77c5b4e09567aa4e59332e8</Hash>
</Codenesium>*/