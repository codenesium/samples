using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CreditCard")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLCreditCardMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLCreditCardMapper();
			ApiCreditCardServerRequestModel model = new ApiCreditCardServerRequestModel();
			model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			BOCreditCard response = mapper.MapModelToBO(1, model);

			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLCreditCardMapper();
			BOCreditCard bo = new BOCreditCard();
			bo.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			ApiCreditCardServerResponseModel response = mapper.MapBOToModel(bo);

			response.CardNumber.Should().Be("A");
			response.CardType.Should().Be("A");
			response.CreditCardID.Should().Be(1);
			response.ExpMonth.Should().Be(1);
			response.ExpYear.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLCreditCardMapper();
			BOCreditCard bo = new BOCreditCard();
			bo.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
			List<ApiCreditCardServerResponseModel> response = mapper.MapBOToModel(new List<BOCreditCard>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6d70e409263a0d84b24d963f50015e57</Hash>
</Codenesium>*/