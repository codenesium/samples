using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Transaction")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTransactionMapper();
			var bo = new BOTransaction();
			bo.SetProperties(1, 1m, "A", 1);

			Transaction response = mapper.MapBOToEF(bo);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.Id.Should().Be(1);
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTransactionMapper();
			Transaction entity = new Transaction();
			entity.SetProperties(1m, "A", 1, 1);

			BOTransaction response = mapper.MapEFToBO(entity);

			response.Amount.Should().Be(1m);
			response.GatewayConfirmationNumber.Should().Be("A");
			response.Id.Should().Be(1);
			response.TransactionStatusId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTransactionMapper();
			Transaction entity = new Transaction();
			entity.SetProperties(1m, "A", 1, 1);

			List<BOTransaction> response = mapper.MapEFToBO(new List<Transaction>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>5413990713e20ab7c73a236eb6b0a8bc</Hash>
</Codenesium>*/