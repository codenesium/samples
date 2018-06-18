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
        [Trait("Table", "Province")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProvinceActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProvinceMapper();

                        ApiProvinceRequestModel model = new ApiProvinceRequestModel();

                        model.SetProperties(1, "A");
                        BOProvince response = mapper.MapModelToBO(1, model);

                        response.CountryId.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProvinceMapper();

                        BOProvince bo = new BOProvince();

                        bo.SetProperties(1, 1, "A");
                        ApiProvinceResponseModel response = mapper.MapBOToModel(bo);

                        response.CountryId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProvinceMapper();

                        BOProvince bo = new BOProvince();

                        bo.SetProperties(1, 1, "A");
                        List<ApiProvinceResponseModel> response = mapper.MapBOToModel(new List<BOProvince>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>dde7d3eb4a45247ed3df03822ba40a9a</Hash>
</Codenesium>*/