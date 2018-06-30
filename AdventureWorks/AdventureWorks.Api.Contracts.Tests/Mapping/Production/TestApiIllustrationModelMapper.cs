using AdventureWorksNS.Api.Contracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Contracts.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Illustration")]
        [Trait("Area", "ApiModel")]
        public class TestApiIllustrationModelMapper
        {
                [Fact]
                public void MapRequestToResponse()
                {
                        var mapper = new ApiIllustrationModelMapper();
                        var model = new ApiIllustrationRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiIllustrationResponseModel response = mapper.MapRequestToResponse(1, model);

                        response.Diagram.Should().Be("A");
                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapResponseToRequest()
                {
                        var mapper = new ApiIllustrationModelMapper();
                        var model = new ApiIllustrationResponseModel();
                        model.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiIllustrationRequestModel response = mapper.MapResponseToRequest(model);

                        response.Diagram.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }
        }
}

/*<Codenesium>
    <Hash>1d16a89feef8b7016d154f04d985458b</Hash>
</Codenesium>*/