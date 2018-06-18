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
        [Trait("Table", "SpaceXSpaceFeature")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSpaceXSpaceFeatureActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSpaceXSpaceFeatureMapper();

                        ApiSpaceXSpaceFeatureRequestModel model = new ApiSpaceXSpaceFeatureRequestModel();

                        model.SetProperties(1, 1);
                        BOSpaceXSpaceFeature response = mapper.MapModelToBO(1, model);

                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSpaceXSpaceFeatureMapper();

                        BOSpaceXSpaceFeature bo = new BOSpaceXSpaceFeature();

                        bo.SetProperties(1, 1, 1);
                        ApiSpaceXSpaceFeatureResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.SpaceFeatureId.Should().Be(1);
                        response.SpaceId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSpaceXSpaceFeatureMapper();

                        BOSpaceXSpaceFeature bo = new BOSpaceXSpaceFeature();

                        bo.SetProperties(1, 1, 1);
                        List<ApiSpaceXSpaceFeatureResponseModel> response = mapper.MapBOToModel(new List<BOSpaceXSpaceFeature>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>26e1d4de10eeb3fa54ae93ff2d71439c</Hash>
</Codenesium>*/