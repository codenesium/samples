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
        [Trait("Table", "Space")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSpaceActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSpaceMapper();

                        ApiSpaceRequestModel model = new ApiSpaceRequestModel();

                        model.SetProperties("A", "A", 1);
                        BOSpace response = mapper.MapModelToBO(1, model);

                        response.Description.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSpaceMapper();

                        BOSpace bo = new BOSpace();

                        bo.SetProperties(1, "A", "A", 1);
                        ApiSpaceResponseModel response = mapper.MapBOToModel(bo);

                        response.Description.Should().Be("A");
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSpaceMapper();

                        BOSpace bo = new BOSpace();

                        bo.SetProperties(1, "A", "A", 1);
                        List<ApiSpaceResponseModel> response = mapper.MapBOToModel(new List<BOSpace>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>80e5e53f09a5593df18db9a5dc65701a</Hash>
</Codenesium>*/