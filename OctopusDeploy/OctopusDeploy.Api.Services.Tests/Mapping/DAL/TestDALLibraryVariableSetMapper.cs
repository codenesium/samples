using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "LibraryVariableSet")]
        [Trait("Area", "DALMapper")]
        public class TestDALLibraryVariableSetActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALLibraryVariableSetMapper();

                        var bo = new BOLibraryVariableSet();

                        bo.SetProperties("A", "A", "A", "A", "A");

                        LibraryVariableSet response = mapper.MapBOToEF(bo);

                        response.ContentType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALLibraryVariableSetMapper();

                        LibraryVariableSet entity = new LibraryVariableSet();

                        entity.SetProperties("A", "A", "A", "A", "A");

                        BOLibraryVariableSet  response = mapper.MapEFToBO(entity);

                        response.ContentType.Should().Be("A");
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.VariableSetId.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALLibraryVariableSetMapper();

                        LibraryVariableSet entity = new LibraryVariableSet();

                        entity.SetProperties("A", "A", "A", "A", "A");

                        List<BOLibraryVariableSet> response = mapper.MapEFToBO(new List<LibraryVariableSet>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>84ac3731667ed76fb0e421d323b61e37</Hash>
</Codenesium>*/