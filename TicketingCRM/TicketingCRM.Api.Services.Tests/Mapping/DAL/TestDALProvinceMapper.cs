using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Province")]
        [Trait("Area", "DALMapper")]
        public class TestDALProvinceActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALProvinceMapper();

                        var bo = new BOProvince();

                        bo.SetProperties(1, 1, "A");

                        Province response = mapper.MapBOToEF(bo);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALProvinceMapper();

                        Province entity = new Province();

                        entity.SetProperties(1, 1, "A");

                        BOProvince  response = mapper.MapEFToBO(entity);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALProvinceMapper();

                        Province entity = new Province();

                        entity.SetProperties(1, 1, "A");

                        List<BOProvince> response = mapper.MapEFToBO(new List<Province>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b8559c1fd42b239d29a83521c6674900</Hash>
</Codenesium>*/