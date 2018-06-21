using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModel")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductModelMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductModelMapper();
                        var bo = new BOProductModel();
                        bo.SetProperties(1, "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        ProductModel response = mapper.MapBOToEF(bo);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductModelMapper();
                        ProductModel entity = new ProductModel();
                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BOProductModel response = mapper.MapEFToBO(entity);

                        response.CatalogDescription.Should().Be("A");
                        response.Instructions.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ProductModelID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductModelMapper();
                        ProductModel entity = new ProductModel();
                        entity.SetProperties("A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BOProductModel> response = mapper.MapEFToBO(new List<ProductModel>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>c52cae6375bf4a60eca329da37df0840</Hash>
</Codenesium>*/