using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionStatuMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTransactionStatuMapper();
			ApiTransactionStatuServerRequestModel model = new ApiTransactionStatuServerRequestModel();
			model.SetProperties("A");
			TransactionStatu response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTransactionStatuMapper();
			TransactionStatu item = new TransactionStatu();
			item.SetProperties(1, "A");
			ApiTransactionStatuServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTransactionStatuMapper();
			TransactionStatu item = new TransactionStatu();
			item.SetProperties(1, "A");
			List<ApiTransactionStatuServerResponseModel> response = mapper.MapEntityToModel(new List<TransactionStatu>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d70e0b721de1b19da6d0b70be1495746</Hash>
</Codenesium>*/