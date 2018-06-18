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
        [Trait("Table", "Rate")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLRateActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLRateMapper();

                        ApiRateRequestModel model = new ApiRateRequestModel();

                        model.SetProperties(1, 1, 1);
                        BORate response = mapper.MapModelToBO(1, model);

                        response.AmountPerMinute.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLRateMapper();

                        BORate bo = new BORate();

                        bo.SetProperties(1, 1, 1, 1);
                        ApiRateResponseModel response = mapper.MapBOToModel(bo);

                        response.AmountPerMinute.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLRateMapper();

                        BORate bo = new BORate();

                        bo.SetProperties(1, 1, 1, 1);
                        List<ApiRateResponseModel> response = mapper.MapBOToModel(new List<BORate>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b1861dd20ac4ce864d1bea1bded6facc</Hash>
</Codenesium>*/