using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductDescription")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductDescriptionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductDescriptionMapper();

                        var bo = new BOProductDescription();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        ProductDescription response = mapper.MapBOToEF(bo);

                        response.Description.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductDescriptionID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductDescriptionMapper();

                        ProductDescription entity = new ProductDescription();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BOProductDescription  response = mapper.MapEFToBO(entity);

                        response.Description.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductDescriptionID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductDescriptionMapper();

                        ProductDescription entity = new ProductDescription();

                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BOProductDescription> response = mapper.MapEFToBO(new List<ProductDescription>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8472789c40a15e92ff6d876b8a1db717</Hash>
</Codenesium>*/