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
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTransactionStatuMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTransactionStatuMapper();
			ApiTransactionStatuRequestModel model = new ApiTransactionStatuRequestModel();
			model.SetProperties("A");
			BOTransactionStatu response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTransactionStatuMapper();
			BOTransactionStatu bo = new BOTransactionStatu();
			bo.SetProperties(1, "A");
			ApiTransactionStatuResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTransactionStatuMapper();
			BOTransactionStatu bo = new BOTransactionStatu();
			bo.SetProperties(1, "A");
			List<ApiTransactionStatuResponseModel> response = mapper.MapBOToModel(new List<BOTransactionStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>647f5f40e2ac519c450418758a504cd5</Hash>
</Codenesium>*/