using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "CreditCard")]
        [Trait("Area", "ApiModel")]
        public class TestApiCreditCardModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCreditCardModelMapper();
                        var model = new ApiCreditCardRequestModel();
                        model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiCreditCardResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.CardNumber.Should().Be("A");
                        response.CardType.Should().Be("A");
                        response.CreditCardID.Should().Be(1);
                        response.ExpMonth.Should().Be(1);
                        response.ExpYear.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCreditCardModelMapper();
                        var model = new ApiCreditCardResponseModel();
                        model.SetProperties(1, "A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiCreditCardRequestModel response = mapper.MapResponseToRequest(model);

                        response.CardNumber.Should().Be("A");
                        response.CardType.Should().Be("A");
                        response.ExpMonth.Should().Be(1);
                        response.ExpYear.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>9ade7b38cd70cb15bb3d0590a6064195</Hash>
</Codenesium>*/