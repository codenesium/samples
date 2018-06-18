using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModelIllustration")]
        [Trait("Area", "DALMapper")]
        public class TestDALProductModelIllustrationActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProductModelIllustrationMapper();

                        var bo = new BOProductModelIllustration();

                        bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        ProductModelIllustration response = mapper.MapBOToEF(bo);

                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductModelID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProductModelIllustrationMapper();

                        ProductModelIllustration entity = new ProductModelIllustration();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        BOProductModelIllustration  response = mapper.MapEFToBO(entity);

                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductModelID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProductModelIllustrationMapper();

                        ProductModelIllustration entity = new ProductModelIllustration();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1);

                        List<BOProductModelIllustration> response = mapper.MapEFToBO(new List<ProductModelIllustration>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0d00312a0cea087201d1d28c3539b844</Hash>
</Codenesium>*/