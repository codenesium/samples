using FermataFishNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace FermataFishNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Rate")]
        [Trait("Area", "ApiModel")]
        public class TestApiRateModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiRateModelMapper();
                        var model = new ApiRateRequestModel();
                        model.SetProperties(1, 1, 1);
                        ApiRateResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.AmountPerMinute.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiRateModelMapper();
                        var model = new ApiRateResponseModel();
                        model.SetProperties(1, 1, 1, 1);
                        ApiRateRequestModel response = mapper.MapResponseToRequest(model);

                        response.AmountPerMinute.Should().Be(1);
                        response.TeacherId.Should().Be(1);
                        response.TeacherSkillId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>8ee0c135cd8eb601afd4eed4f4cb57ba</Hash>
</Codenesium>*/