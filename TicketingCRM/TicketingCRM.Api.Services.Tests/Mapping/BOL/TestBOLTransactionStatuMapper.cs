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
			ApiTransactionStatuServerRequestModel model = new ApiTransactionStatuServerRequestModel();
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
			ApiTransactionStatuServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTransactionStatuMapper();
			BOTransactionStatu bo = new BOTransactionStatu();
			bo.SetProperties(1, "A");
			List<ApiTransactionStatuServerResponseModel> response = mapper.MapBOToModel(new List<BOTransactionStatu>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>857e5e00dc75f0b9f9cfa42e68b0bb9f</Hash>
</Codenesium>*/