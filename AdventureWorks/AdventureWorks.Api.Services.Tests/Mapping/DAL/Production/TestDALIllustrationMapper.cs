using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Illustration")]
        [Trait("Area", "DALMapper")]
        public class TestDALIllustrationMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALIllustrationMapper();
                        var bo = new BOIllustration();
                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));

                        Illustration response = mapper.MapBOToEF(bo);

                        response.Diagram.Should().Be("A");
                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALIllustrationMapper();
                        Illustration entity = new Illustration();
                        entity.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        BOIllustration response = mapper.MapEFToBO(entity);

                        response.Diagram.Should().Be("A");
                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALIllustrationMapper();
                        Illustration entity = new Illustration();
                        entity.SetProperties("A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

                        List<BOIllustration> response = mapper.MapEFToBO(new List<Illustration>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a31425eb2d96f2e82d774137bf94f2f3</Hash>
</Codenesium>*/