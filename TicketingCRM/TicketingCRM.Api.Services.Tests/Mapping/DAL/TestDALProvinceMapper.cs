using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Province")]
        [Trait("Area", "DALMapper")]
        public class TestDALProvinceMapper
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

                        BOProvince response = mapper.MapEFToBO(entity);

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
    <Hash>11a14bcc7a340d1c2cbd620288c27cea</Hash>
</Codenesium>*/