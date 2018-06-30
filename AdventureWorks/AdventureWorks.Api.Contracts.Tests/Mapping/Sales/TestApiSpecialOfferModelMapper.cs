using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpecialOffer")]
        [Trait("Area", "ApiModel")]
        public class TestApiSpecialOfferModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiSpecialOfferModelMapper();
                        var model = new ApiSpecialOfferRequestModel();
                        model.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiSpecialOfferResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Category.Should().Be("A");
                        response.Description.Should().Be("A");
                        response.DiscountPct.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxQty.Should().Be(1);
                        response.MinQty.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SpecialOfferID.Should().Be(1);
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiSpecialOfferModelMapper();
                        var model = new ApiSpecialOfferResponseModel();
                        model.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiSpecialOfferRequestModel response = mapper.MapResponseToRequest(model);

                        response.Category.Should().Be("A");
                        response.Description.Should().Be("A");
                        response.DiscountPct.Should().Be(1);
                        response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.MaxQty.Should().Be(1);
                        response.MinQty.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Type.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>35b58725ccd2d1458cf9452b8dbbf82d</Hash>
</Codenesium>*/