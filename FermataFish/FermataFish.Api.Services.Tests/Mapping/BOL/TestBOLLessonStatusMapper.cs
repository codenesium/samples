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
        [Trait("Table", "LessonStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLessonStatusActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLessonStatusMapper();

                        ApiLessonStatusRequestModel model = new ApiLessonStatusRequestModel();

                        model.SetProperties("A", 1);
                        BOLessonStatus response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLessonStatusMapper();

                        BOLessonStatus bo = new BOLessonStatus();

                        bo.SetProperties(1, "A", 1);
                        ApiLessonStatusResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.StudioId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLessonStatusMapper();

                        BOLessonStatus bo = new BOLessonStatus();

                        bo.SetProperties(1, "A", 1);
                        List<ApiLessonStatusResponseModel> response = mapper.MapBOToModel(new List<BOLessonStatus>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>70086b0d29ccfb6ce1168e172d3e5578</Hash>
</Codenesium>*/