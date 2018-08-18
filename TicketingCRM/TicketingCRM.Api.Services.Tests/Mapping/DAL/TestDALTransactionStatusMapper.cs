using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionStatusMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTransactionStatusMapper();
			var bo = new BOTransactionStatus();
			bo.SetProperties(1, "A");

			TransactionStatus response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTransactionStatusMapper();
			TransactionStatus entity = new TransactionStatus();
			entity.SetProperties(1, "A");

			BOTransactionStatus response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTransactionStatusMapper();
			TransactionStatus entity = new TransactionStatus();
			entity.SetProperties(1, "A");

			List<BOTransactionStatus> response = mapper.MapEFToBO(new List<TransactionStatus>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1920491dd1229085e1024fd8f6f7dde0</Hash>
</Codenesium>*/