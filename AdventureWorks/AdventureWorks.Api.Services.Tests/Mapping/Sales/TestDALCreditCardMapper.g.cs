using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "DALMapper")]
	public class TestDALCreditCardMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCreditCardMapper();
			ApiCreditCardServerRequestModel model = new ApiCreditCardServerRequestModel();
			model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			CreditCard response = mapper.MapModelToEntity(1, model);

			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCreditCardMapper();
			CreditCard item = new CreditCard();
			item.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardServerResponseModel response = mapper.MapEntityToModel(item);

			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCreditCardMapper();
			CreditCard item = new CreditCard();
			item.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiCreditCardServerResponseModel> response = mapper.MapEntityToModel(new List<CreditCard>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b9fbd11895d0081e7302d429fc11b639</Hash>
</Codenesium>*/