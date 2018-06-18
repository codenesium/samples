using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "City")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCityActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCityMapper();

                        ApiCityRequestModel model = new ApiCityRequestModel();

                        model.SetProperties("A", 1);
                        BOCity response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                        response.ProvinceId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCityMapper();

                        BOCity bo = new BOCity();

                        bo.SetProperties(1, "A", 1);
                        ApiCityResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.ProvinceId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCityMapper();

                        BOCity bo = new BOCity();

                        bo.SetProperties(1, "A", 1);
                        List<ApiCityResponseModel> response = mapper.MapBOToModel(new List<BOCity>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>eecb29bbb7b376ec0582468ff130d3db</Hash>
</Codenesium>*/