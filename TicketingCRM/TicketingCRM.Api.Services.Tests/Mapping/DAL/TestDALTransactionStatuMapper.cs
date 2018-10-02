using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "DALMapper")]
	public class TestDALTransactionStatuMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTransactionStatuMapper();
			var bo = new BOTransactionStatu();
			bo.SetProperties(1, "A");

			TransactionStatu response = mapper.MapBOToEF(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTransactionStatuMapper();
			TransactionStatu entity = new TransactionStatu();
			entity.SetProperties(1, "A");

			BOTransactionStatu response = mapper.MapEFToBO(entity);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTransactionStatuMapper();
			TransactionStatu entity = new TransactionStatu();
			entity.SetProperties(1, "A");

			List<BOTransactionStatu> response = mapper.MapEFToBO(new List<TransactionStatu>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a1065aafed0d020eff0907a53795f146</Hash>
</Codenesium>*/