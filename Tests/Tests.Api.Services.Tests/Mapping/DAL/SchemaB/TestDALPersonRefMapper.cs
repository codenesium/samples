using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonRef")]
        [Trait("Area", "DALMapper")]
        public class TestDALPersonRefMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALPersonRefMapper();
                        var bo = new BOPersonRef();
                        bo.SetProperties(1, 1, 1);

                        PersonRef response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.PersonAId.Should().Be(1);
                        response.PersonBId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALPersonRefMapper();
                        PersonRef entity = new PersonRef();
                        entity.SetProperties(1, 1, 1);

                        BOPersonRef response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.PersonAId.Should().Be(1);
                        response.PersonBId.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALPersonRefMapper();
                        PersonRef entity = new PersonRef();
                        entity.SetProperties(1, 1, 1);

                        List<BOPersonRef> response = mapper.MapEFToBO(new List<PersonRef>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>132f396ed3b67bef56d49ca588684efd</Hash>
</Codenesium>*/