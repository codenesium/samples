using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Contracts.Tests
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
                        model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        ApiSaleResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Amount.Should().Be(1m);
                        response.ClientId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PetId.Should().Be(1);
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesPersonId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSaleModelMapper();
                        var model = new ApiSaleResponseModel();
                        model.SetProperties(1, 1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        ApiSaleRequestModel response = mapper.MapResponseToRequest(model);

                        response.Amount.Should().Be(1m);
                        response.ClientId.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PetId.Should().Be(1);
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesPersonId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiSaleModelMapper();
                        var model = new ApiSaleRequestModel();
                        model.SetProperties(1m, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        JsonPatchDocument<ApiSaleRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiSaleRequestModel();
                        patch.ApplyTo(response);

                        response.Amount.Should().Be(1m);
                        response.ClientId.Should().Be(1);
                        response.Note.Should().Be("A");
                        response.PetId.Should().Be(1);
                        response.SaleDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.SalesPersonId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2db6289d057ed589a3e665d60c4c1166</Hash>
</Codenesium>*/