using FluentAssertions;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PaymentType")]
        [Trait("Area", "ApiModel")]
        public class TestApiPaymentTypeModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPaymentTypeModelMapper();
                        var model = new ApiPaymentTypeRequestModel();
                        model.SetProperties("A");
                        ApiPaymentTypeResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPaymentTypeModelMapper();
                        var model = new ApiPaymentTypeResponseModel();
                        model.SetProperties(1, "A");
                        ApiPaymentTypeRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>10f97c65b5e39ced8871087dbaf670ab</Hash>
</Codenesium>*/