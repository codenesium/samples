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
	[Trait("Table", "TicketStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTicketStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTicketStatuMapper();
			ApiTicketStatuServerRequestModel model = new ApiTicketStatuServerRequestModel();
			model.SetProperties("A");
			BOTicketStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTicketStatuMapper();
			BOTicketStatu bo = new BOTicketStatu();
			bo.SetProperties(1, "A");
			ApiTicketStatuServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTicketStatuMapper();
			BOTicketStatu bo = new BOTicketStatu();
			bo.SetProperties(1, "A");
			List<ApiTicketStatuServerResponseModel> response = mapper.MapBOToModel(new List<BOTicketStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ac063b4679f1114c82febcdf897dd849</Hash>
</Codenesium>*/