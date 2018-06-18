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
        [Trait("Table", "Culture")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLCultureActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLCultureMapper();

                        ApiCultureRequestModel model = new ApiCultureRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        BOCulture response = mapper.MapModelToBO("A", model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLCultureMapper();

                        BOCulture bo = new BOCulture();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        ApiCultureResponseModel response = mapper.MapBOToModel(bo);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLCultureMapper();

                        BOCulture bo = new BOCulture();

                        bo.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
                        List<ApiCultureResponseModel> response = mapper.MapBOToModel(new List<BOCulture>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>235105d2bb2d13de5ea4f0a73f25ee77</Hash>
</Codenesium>*/