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
        [Trait("Table", "SpaceFeature")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSpaceFeatureActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSpaceFeatureMapper();

                        ApiSpaceFeatureRequestModel model = new ApiSpaceFeatureRequestModel();

                        model.SetProperties("A", 1);
                        BOSpaceFeature response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSpaceFeatureMapper();

                        BOSpaceFeature bo = new BOSpaceFeature();

                        bo.SetProperties(1, "A", 1);
                        ApiSpaceFeatureResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSpaceFeatureMapper();

                        BOSpaceFeature bo = new BOSpaceFeature();

                        bo.SetProperties(1, "A", 1);
                        List<ApiSpaceFeatureResponseModel> response = mapper.MapBOToModel(new List<BOSpaceFeature>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>850ccdcfad26572523009cb3cedadd3a</Hash>
</Codenesium>*/