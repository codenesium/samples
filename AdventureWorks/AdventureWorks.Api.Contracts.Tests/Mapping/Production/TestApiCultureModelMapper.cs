using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Culture")]
        [Trait("Area", "ApiModel")]
        public class TestApiCultureModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiCultureModelMapper();
                        var model = new ApiCultureRequestModel();
                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCultureResponseModel response = mapper.MapRequestToResponse("A", model);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiCultureModelMapper();
                        var model = new ApiCultureResponseModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCultureRequestModel response = mapper.MapResponseToRequest(model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }
        }
}

/*<Codenesium>
    <Hash>4390f50ba9a41ff3483bdda3f09f8e92</Hash>
</Codenesium>*/