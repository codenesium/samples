using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALTransactionStatusMapper();
			ApiTransactionStatusServerRequestModel model = new ApiTransactionStatusServerRequestModel();
			model.SetProperties("A");
			TransactionStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALTransactionStatusMapper();
			TransactionStatus item = new TransactionStatus();
			item.SetProperties(1, "A");
			ApiTransactionStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALTransactionStatusMapper();
			TransactionStatus item = new TransactionStatus();
			item.SetProperties(1, "A");
			List<ApiTransactionStatusServerResponseModel> response = mapper.MapEntityToModel(new List<TransactionStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>84d66f00d0d9d5485d04d01a3ecb0581</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/