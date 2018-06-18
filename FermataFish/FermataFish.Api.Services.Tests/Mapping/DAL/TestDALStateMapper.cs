using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "State")]
        [Trait("Area", "DALMapper")]
        public class TestDALStateActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALStateMapper();

                        var bo = new BOState();

                        bo.SetProperties(1, "A");

                        State response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALStateMapper();

                        State entity = new State();

                        entity.SetProperties(1, "A");

                        BOState  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALStateMapper();

                        State entity = new State();

                        entity.SetProperties(1, "A");

                        List<BOState> response = mapper.MapEFToBO(new List<State>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9e0baf2576dba8bd061aa39c7c7fb3af</Hash>
</Codenesium>*/