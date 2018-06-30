using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Mutex")]
        [Trait("Area", "ApiModel")]
        public class TestApiMutexModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiMutexModelMapper();
                        var model = new ApiMutexRequestModel();
                        model.SetProperties("A");
                        ApiMutexResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiMutexModelMapper();
                        var model = new ApiMutexResponseModel();
                        model.SetProperties("A", "A");
                        ApiMutexRequestModel response = mapper.MapResponseToRequest(model);

                        response.JSON.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>cd8299efb901659011869cbe78a4c7ba</Hash>
</Codenesium>*/