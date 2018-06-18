using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "AddressType")]
        [Trait("Area", "DALMapper")]
        public class TestDALAddressTypeActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALAddressTypeMapper();

                        var bo = new BOAddressType();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        AddressType response = mapper.MapBOToEF(bo);

                        response.AddressTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALAddressTypeMapper();

                        AddressType entity = new AddressType();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        BOAddressType  response = mapper.MapEFToBO(entity);

                        response.AddressTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALAddressTypeMapper();

                        AddressType entity = new AddressType();

                        entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));

                        List<BOAddressType> response = mapper.MapEFToBO(new List<AddressType>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>5332761005b5b45daebc2d4b33866fdc</Hash>
</Codenesium>*/