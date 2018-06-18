using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductProductPhotoActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductProductPhotoMapper();

                        var bo = new BOProductProductPhoto();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);

                        ProductProductPhoto response = mapper.MapBOToEF(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductID.Should().Be(1);
                        response.ProductPhotoID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductProductPhotoMapper();

                        ProductProductPhoto entity = new ProductProductPhoto();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, 1);

                        BOProductProductPhoto  response = mapper.MapEFToBO(entity);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductID.Should().Be(1);
                        response.ProductPhotoID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductProductPhotoMapper();

                        ProductProductPhoto entity = new ProductProductPhoto();

                        entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1, 1);

                        List<BOProductProductPhoto> response = mapper.MapEFToBO(new List<ProductProductPhoto>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>07a5f6d09ed36bf511cdc5e8f925f8dd</Hash>
</Codenesium>*/