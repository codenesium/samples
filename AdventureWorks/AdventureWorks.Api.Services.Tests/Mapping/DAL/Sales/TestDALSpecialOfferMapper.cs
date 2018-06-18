using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "SpecialOffer")]
        [Trait("Area", "DALMapper")]
        public class TestDALSpecialOfferActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSpecialOfferMapper();

                        var bo = new BOSpecialOffer();

                        bo.SetProperties(1, "A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        SpecialOffer response = mapper.MapBOToEF(bo);

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
                public void MapEFToBO()
                {
                        var mapper = new DALSpecialOfferMapper();

                        SpecialOffer entity = new SpecialOffer();

                        entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOSpecialOffer  response = mapper.MapEFToBO(entity);

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
                public void MapEFToBOList()
                {
                        var mapper = new DALSpecialOfferMapper();

                        SpecialOffer entity = new SpecialOffer();

                        entity.SetProperties("A", "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOSpecialOffer> response = mapper.MapEFToBO(new List<SpecialOffer>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0403ec42bfe4453377b1a9a00e83003f</Hash>
</Codenesium>*/