using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Person")]
        [Trait("Area", "DALMapper")]
        public class TestDALPersonMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPersonMapper();
                        var bo = new BOPerson();
                        bo.SetProperties(1, "A");

                        Person response = mapper.MapBOToEF(bo);

                        response.PersonId.Should().Be(1);
                        response.PersonName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPersonMapper();
                        Person entity = new Person();
                        entity.SetProperties(1, "A");

                        BOPerson response = mapper.MapEFToBO(entity);

                        response.PersonId.Should().Be(1);
                        response.PersonName.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPersonMapper();
                        Person entity = new Person();
                        entity.SetProperties(1, "A");

                        List<BOPerson> response = mapper.MapEFToBO(new List<Person>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1ccfa5e4df8eab94477f39a1b6884ae6</Hash>
</Codenesium>*/