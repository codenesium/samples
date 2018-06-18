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
        [Trait("Table", "ProductProductPhoto")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProductProductPhotoActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProductProductPhotoMapper();

                        ApiProductProductPhotoRequestModel model = new ApiProductProductPhotoRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
                        BOProductProductPhoto response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductPhotoID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProductProductPhotoMapper();

                        BOProductProductPhoto bo = new BOProductProductPhoto();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
                        ApiProductProductPhotoResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Primary.Should().Be(true);
                        response.ProductID.Should().Be(1);
                        response.ProductPhotoID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProductProductPhotoMapper();

                        BOProductProductPhoto bo = new BOProductProductPhoto();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), true, 1);
                        List<ApiProductProductPhotoResponseModel> response = mapper.MapBOToModel(new List<BOProductProductPhoto>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>64a36b2212b3ab1acf8b5670b738d1fc</Hash>
</Codenesium>*/