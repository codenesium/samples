using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Customer")]
        [Trait("Area", "ApiModel")]
        public class TestApiCustomerModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCustomerModelMapper();
                        var model = new ApiCustomerRequestModel();
                        model.SetProperties("A", "A", "A", "A");
                        ApiCustomerResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCustomerModelMapper();
                        var model = new ApiCustomerResponseModel();
                        model.SetProperties(1, "A", "A", "A", "A");
                        ApiCustomerRequestModel response = mapper.MapResponseToRequest(model);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiCustomerModelMapper();
                        var model = new ApiCustomerRequestModel();
                        model.SetProperties("A", "A", "A", "A");

                        JsonPatchDocument<ApiCustomerRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiCustomerRequestModel();
                        patch.ApplyTo(response);

                        response.Email.Should().Be("A");
                        response.FirstName.Should().Be("A");
                        response.LastName.Should().Be("A");
                        response.Phone.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2c225792d199d4fec1e9ac6cbab1b2ba</Hash>
</Codenesium>*/