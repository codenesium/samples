using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "BusinessEntityAddress")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLBusinessEntityAddressActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLBusinessEntityAddressMapper();

                        ApiBusinessEntityAddressRequestModel model = new ApiBusinessEntityAddressRequestModel();

                        model.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        BOBusinessEntityAddress response = mapper.MapModelToBO(1, model);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLBusinessEntityAddressMapper();

                        BOBusinessEntityAddress bo = new BOBusinessEntityAddress();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiBusinessEntityAddressResponseModel response = mapper.MapBOToModel(bo);

                        response.AddressID.Should().Be(1);
                        response.AddressTypeID.Should().Be(1);
                        response.BusinessEntityID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLBusinessEntityAddressMapper();

                        BOBusinessEntityAddress bo = new BOBusinessEntityAddress();

                        bo.SetProperties(1, 1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        List<ApiBusinessEntityAddressResponseModel> response = mapper.MapBOToModel(new List<BOBusinessEntityAddress>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>a440387ccea211f423f0bbe748b3e61d</Hash>
</Codenesium>*/