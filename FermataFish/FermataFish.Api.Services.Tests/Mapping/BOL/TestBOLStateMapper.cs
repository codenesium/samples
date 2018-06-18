using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "State")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLStateActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLStateMapper();

                        ApiStateRequestModel model = new ApiStateRequestModel();

                        model.SetProperties("A");
                        BOState response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLStateMapper();

                        BOState bo = new BOState();

                        bo.SetProperties(1, "A");
                        ApiStateResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLStateMapper();

                        BOState bo = new BOState();

                        bo.SetProperties(1, "A");
                        List<ApiStateResponseModel> response = mapper.MapBOToModel(new List<BOState>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>85194374276f46b641d6faa587d93739</Hash>
</Codenesium>*/