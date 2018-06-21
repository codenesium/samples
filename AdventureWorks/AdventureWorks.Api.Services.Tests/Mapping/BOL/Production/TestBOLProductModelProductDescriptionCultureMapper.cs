using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ProductModelProductDescriptionCulture")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductModelProductDescriptionCultureMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductModelProductDescriptionCultureMapper();
                        ApiProductModelProductDescriptionCultureRequestModel model = new ApiProductModelProductDescriptionCultureRequestModel();
                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        BOProductModelProductDescriptionCulture response = mapper.MapModelToBO(1, model);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductDescriptionID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductModelProductDescriptionCultureMapper();
                        BOProductModelProductDescriptionCulture bo = new BOProductModelProductDescriptionCulture();
                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        ApiProductModelProductDescriptionCultureResponseModel response = mapper.MapBOToModel(bo);

                        response.CultureID.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductDescriptionID.Should().Be(1);
                        response.ProductModelID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductModelProductDescriptionCultureMapper();
                        BOProductModelProductDescriptionCulture bo = new BOProductModelProductDescriptionCulture();
                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
                        List<ApiProductModelProductDescriptionCultureResponseModel> response = mapper.MapBOToModel(new List<BOProductModelProductDescriptionCulture>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b8e91713f5fca59d3c72c99e5cbef5c3</Hash>
</Codenesium>*/