using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "StateProvince")]
        [Trait("Area", "DALMapper")]
        public class TestDALStateProvinceActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALStateProvinceMapper();

                        var bo = new BOStateProvince();

                        bo.SetProperties(1, "A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1);

                        StateProvince response = mapper.MapBOToEF(bo);

                        response.CountryRegionCode.Should().Be("A");
                        response.IsOnlyStateProvinceFlag.Should().Be(true);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StateProvinceCode.Should().Be("A");
                        response.StateProvinceID.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALStateProvinceMapper();

                        StateProvince entity = new StateProvince();

                        entity.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, 1);

                        BOStateProvince  response = mapper.MapEFToBO(entity);

                        response.CountryRegionCode.Should().Be("A");
                        response.IsOnlyStateProvinceFlag.Should().Be(true);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.StateProvinceCode.Should().Be("A");
                        response.StateProvinceID.Should().Be(1);
                        response.TerritoryID.Should().Be(1);
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALStateProvinceMapper();

                        StateProvince entity = new StateProvince();

                        entity.SetProperties("A", true, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", 1, 1);

                        List<BOStateProvince> response = mapper.MapEFToBO(new List<StateProvince>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>834b93e5942044c5f4823ff668c666af</Hash>
</Codenesium>*/