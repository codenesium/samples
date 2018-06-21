using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Culture")]
        [Trait("Area", "DALMapper")]
        public class TestDALCultureMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALCultureMapper();
                        var bo = new BOCulture();
                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        Culture response = mapper.MapBOToEF(bo);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALCultureMapper();
                        Culture entity = new Culture();
                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        BOCulture response = mapper.MapEFToBO(entity);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALCultureMapper();
                        Culture entity = new Culture();
                        entity.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        List<BOCulture> response = mapper.MapEFToBO(new List<Culture>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4aa1a2304ee3a7060159dc0b42b5f96d</Hash>
</Codenesium>*/