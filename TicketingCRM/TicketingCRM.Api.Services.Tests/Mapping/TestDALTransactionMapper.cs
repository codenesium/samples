using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTransactionMapper();
			ApiTransactionServerRequestModel model = new ApiTransactionServerRequestModel();
			model.SetProperties(1m, "A", 1);
			Transaction response = mapper.MapModelToEntity(1, model);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTransactionMapper();
			Transaction item = new Transaction();
			item.SetProperties(1, 1m, "A", 1);
			ApiTransactionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.Id.Should().Be(1);
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTransactionMapper();
			Transaction item = new Transaction();
			item.SetProperties(1, 1m, "A", 1);
			List<ApiTransactionServerResponseModel> response = mapper.MapEntityToModel(new List<Transaction>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>30f7626f71da49be85046c1c37615845</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/