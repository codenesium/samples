using FluentAssertions;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Sale")]
        [Trait("Area", "ApiModel")]
        public class TestApiSaleModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSaleModelMapper();
                        var model = new ApiSaleRequestModel();
                        model.SetProperties(1, "A", "A", 1, 1, "A");
                        ApiSaleResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSaleModelMapper();
                        var model = new ApiSaleResponseModel();
                        model.SetProperties(1, 1, "A", "A", 1, 1, "A");
                        ApiSaleRequestModel response = mapper.MapResponseToRequest(model);

                        response.Amount.Should().Be(1);
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.PaymentTypeId.Should().Be(1);
                        response.PetId.Should().Be(1);
                        response.Phone.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>196ced140db0d256d58fb24f694570cf</Hash>
</Codenesium>*/