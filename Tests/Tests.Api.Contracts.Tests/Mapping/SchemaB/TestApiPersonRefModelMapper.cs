using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using Xunit;

namespace TestsNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PersonRef")]
        [Trait("Area", "ApiModel")]
        public class TestApiPersonRefModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiPersonRefModelMapper();
                        var model = new ApiPersonRefRequestModel();
                        model.SetProperties(1, 1);
                        ApiPersonRefResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.PersonAId.Should().Be(1);
                        response.PersonBId.Should().Be(1);
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiPersonRefModelMapper();
                        var model = new ApiPersonRefResponseModel();
                        model.SetProperties(1, 1, 1);
                        ApiPersonRefRequestModel response = mapper.MapResponseToRequest(model);

                        response.PersonAId.Should().Be(1);
                        response.PersonBId.Should().Be(1);
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiPersonRefModelMapper();
                        var model = new ApiPersonRefRequestModel();
                        model.SetProperties(1, 1);

                        JsonPatchDocument<ApiPersonRefRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiPersonRefRequestModel();
                        patch.ApplyTo(response);

                        response.PersonAId.Should().Be(1);
                        response.PersonBId.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>41070c967b7d1b98192d741af3d97f39</Hash>
</Codenesium>*/