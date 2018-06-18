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
        [Trait("Table", "ScrapReason")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLScrapReasonActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLScrapReasonMapper();

                        ApiScrapReasonRequestModel model = new ApiScrapReasonRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOScrapReason response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLScrapReasonMapper();

                        BOScrapReason bo = new BOScrapReason();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiScrapReasonResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.ScrapReasonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLScrapReasonMapper();

                        BOScrapReason bo = new BOScrapReason();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiScrapReasonResponseModel> response = mapper.MapBOToModel(new List<BOScrapReason>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2ebec385b3a7ee0563b449dd36663052</Hash>
</Codenesium>*/