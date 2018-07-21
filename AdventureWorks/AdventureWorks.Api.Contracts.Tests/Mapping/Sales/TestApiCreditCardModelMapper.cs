using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
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

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiCreditCardModelMapper();
                        var model = new ApiCreditCardRequestModel();
                        model.SetProperties("A", "A", 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        JsonPatchDocument<ApiCreditCardRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiCreditCardRequestModel();
                        patch.ApplyTo(response);

                        response.CardNumber.Should().Be("A");
                        response.CardType.Should().Be("A");
                        response.ExpMonth.Should().Be(1);
                        response.ExpYear.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>c8be7518a60960d5da15d3116dc64cb8</Hash>
</Codenesium>*/