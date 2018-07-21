using FileServiceNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace FileServiceNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "FileType")]
        [Trait("Area", "ApiModel")]
        public class TestApiFileTypeModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiFileTypeModelMapper();
                        var model = new ApiFileTypeRequestModel();
                        model.SetProperties("A");
                        ApiFileTypeResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiFileTypeModelMapper();
                        var model = new ApiFileTypeResponseModel();
                        model.SetProperties(1, "A");
                        ApiFileTypeRequestModel response = mapper.MapResponseToRequest(model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiFileTypeModelMapper();
                        var model = new ApiFileTypeRequestModel();
                        model.SetProperties("A");

                        JsonPatchDocument<ApiFileTypeRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiFileTypeRequestModel();
                        patch.ApplyTo(response);

                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>2a462a29411fabd9e348efd685df3462</Hash>
</Codenesium>*/