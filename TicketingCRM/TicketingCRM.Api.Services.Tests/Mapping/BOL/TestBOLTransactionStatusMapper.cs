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
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTransactionStatusMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTransactionStatusMapper();
			ApiTransactionStatusRequestModel model = new ApiTransactionStatusRequestModel();
			model.SetProperties("A");
			BOTransactionStatus response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTransactionStatusMapper();
			BOTransactionStatus bo = new BOTransactionStatus();
			bo.SetProperties(1, "A");
			ApiTransactionStatusResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTransactionStatusMapper();
			BOTransactionStatus bo = new BOTransactionStatus();
			bo.SetProperties(1, "A");
			List<ApiTransactionStatusResponseModel> response = mapper.MapBOToModel(new List<BOTransactionStatus>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>db24b541c5e47c3fdc4d32cb1dd80747</Hash>
</Codenesium>*/