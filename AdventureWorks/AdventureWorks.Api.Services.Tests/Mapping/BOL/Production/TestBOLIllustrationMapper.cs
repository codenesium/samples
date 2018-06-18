using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Illustration")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLIllustrationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLIllustrationMapper();

                        ApiIllustrationRequestModel model = new ApiIllustrationRequestModel();

                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        BOIllustration response = mapper.MapModelToBO(1, model);

                        response.Diagram.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLIllustrationMapper();

                        BOIllustration bo = new BOIllustration();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        ApiIllustrationResponseModel response = mapper.MapBOToModel(bo);

                        response.Diagram.Should().Be("A");
                        response.IllustrationID.Should().Be(1);
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLIllustrationMapper();

                        BOIllustration bo = new BOIllustration();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"));
                        List<ApiIllustrationResponseModel> response = mapper.MapBOToModel(new List<BOIllustration>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>7de02b359926a37964c7ffae06fe19b9</Hash>
</Codenesium>*/