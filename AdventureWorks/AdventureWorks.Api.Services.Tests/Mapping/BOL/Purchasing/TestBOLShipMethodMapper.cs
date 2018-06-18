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
        [Trait("Table", "ShipMethod")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLShipMethodActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLShipMethodMapper();

                        ApiShipMethodRequestModel model = new ApiShipMethodRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        BOShipMethod response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1);
                        response.ShipRate.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLShipMethodMapper();

                        BOShipMethod bo = new BOShipMethod();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        ApiShipMethodResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.ShipBase.Should().Be(1);
                        response.ShipMethodID.Should().Be(1);
                        response.ShipRate.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLShipMethodMapper();

                        BOShipMethod bo = new BOShipMethod();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1, 1);
                        List<ApiShipMethodResponseModel> response = mapper.MapBOToModel(new List<BOShipMethod>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>43d0cb0557ce74b1fd1d3290bc6ff33f</Hash>
</Codenesium>*/