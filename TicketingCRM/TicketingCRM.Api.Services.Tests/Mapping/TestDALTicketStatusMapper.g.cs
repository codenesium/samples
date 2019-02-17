using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TicketStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALTicketStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTicketStatusMapper();
			ApiTicketStatusServerRequestModel model = new ApiTicketStatusServerRequestModel();
			model.SetProperties("A");
			TicketStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTicketStatusMapper();
			TicketStatus item = new TicketStatus();
			item.SetProperties(1, "A");
			ApiTicketStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTicketStatusMapper();
			TicketStatus item = new TicketStatus();
			item.SetProperties(1, "A");
			List<ApiTicketStatusServerResponseModel> response = mapper.MapEntityToModel(new List<TicketStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>afa500c18319dc3c623ab1c9e5dc7f72</Hash>
</Codenesium>*/