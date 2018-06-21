using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "DALMapper")]
        public class TestDALBusinessEntityAddressMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALBusinessEntityAddressMapper();
                        var bo = new BOBusinessEntityAddress();
                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BusinessEntityAddress response = mapper.MapBOToEF(bo);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALBusinessEntityAddressMapper();
                        BusinessEntityAddress entity = new BusinessEntityAddress();
                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BOBusinessEntityAddress response = mapper.MapEFToBO(entity);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALBusinessEntityAddressMapper();
                        BusinessEntityAddress entity = new BusinessEntityAddress();
                        entity.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BOBusinessEntityAddress> response = mapper.MapEFToBO(new List<BusinessEntityAddress>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>fc9273d12cf84f652c3bcd2e686f9277</Hash>
</Codenesium>*/