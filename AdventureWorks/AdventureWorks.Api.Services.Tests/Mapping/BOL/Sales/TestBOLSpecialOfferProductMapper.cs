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
        [Trait("Table", "SpecialOfferProduct")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSpecialOfferProductActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSpecialOfferProductMapper();

                        ApiSpecialOfferProductRequestModel model = new ApiSpecialOfferProductRequestModel();

                        model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        BOSpecialOfferProduct response = mapper.MapModelToBO(1, model);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSpecialOfferProductMapper();

                        BOSpecialOfferProduct bo = new BOSpecialOfferProduct();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiSpecialOfferProductResponseModel response = mapper.MapBOToModel(bo);

                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.ProductID.Should().Be(1);
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SpecialOfferID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSpecialOfferProductMapper();

                        BOSpecialOfferProduct bo = new BOSpecialOfferProduct();

                        bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        List<ApiSpecialOfferProductResponseModel> response = mapper.MapBOToModel(new List<BOSpecialOfferProduct>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>885c0f5a503986052f8e31e90627ba18</Hash>
</Codenesium>*/