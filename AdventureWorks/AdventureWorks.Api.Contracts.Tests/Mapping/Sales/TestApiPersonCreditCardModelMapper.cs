using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonCreditCard")]
        [Trait("Area", "ApiModel")]
        public class TestApiPersonCreditCardModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPersonCreditCardModelMapper();
                        var model = new ApiPersonCreditCardRequestModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiPersonCreditCardResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.BusinessEntityID.Should().Be(1);
                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPersonCreditCardModelMapper();
                        var model = new ApiPersonCreditCardResponseModel();
                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiPersonCreditCardRequestModel response = mapper.MapResponseToRequest(model);

                        response.CreditCardID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>9609dc3c0d91a2ad01c3de01d6899406</Hash>
</Codenesium>*/