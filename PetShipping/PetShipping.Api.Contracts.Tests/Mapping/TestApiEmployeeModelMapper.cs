using FluentAssertions;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Employee")]
        [Trait("Area", "ApiModel")]
        public class TestApiEmployeeModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiEmployeeModelMapper();
                        var model = new ApiEmployeeRequestModel();
                        model.SetProperties("A", true, true, "A");
                        ApiEmployeeResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.IsSalesPerson.Should().Be(true);
                        response.IsShipper.Should().Be(true);
                        response.LastName.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiEmployeeModelMapper();
                        var model = new ApiEmployeeResponseModel();
                        model.SetProperties(1, "A", true, true, "A");
                        ApiEmployeeRequestModel response = mapper.MapResponseToRequest(model);

                        response.FirstName.Should().Be("A");
                        response.IsSalesPerson.Should().Be(true);
                        response.IsShipper.Should().Be(true);
                        response.LastName.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>444418ed67416dbebd21bd4d99e293e2</Hash>
</Codenesium>*/