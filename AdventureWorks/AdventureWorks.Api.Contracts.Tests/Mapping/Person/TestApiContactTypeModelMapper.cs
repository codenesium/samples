using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ContactType")]
        [Trait("Area", "ApiModel")]
        public class TestApiContactTypeModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiContactTypeModelMapper();
                        var model = new ApiContactTypeRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiContactTypeResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.ContactTypeID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiContactTypeModelMapper();
                        var model = new ApiContactTypeResponseModel();
                        model.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiContactTypeRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void CreatePatch()
                {
                        var mapper = new ApiContactTypeModelMapper();
                        var model = new ApiContactTypeRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

                        JsonPatchDocument<ApiContactTypeRequestModel> patch = mapper.CreatePatch(model);
                        var response = new ApiContactTypeRequestModel();
                        patch.ApplyTo(response);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>c0a49e67d23d9087893aff26be2bd64a</Hash>
</Codenesium>*/