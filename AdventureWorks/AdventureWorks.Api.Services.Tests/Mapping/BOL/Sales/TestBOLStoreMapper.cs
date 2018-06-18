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
        [Trait("Table", "Store")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLStoreActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLStoreMapper();

                        ApiStoreRequestModel model = new ApiStoreRequestModel();

                        model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        BOStore response = mapper.MapModelToBO(1, model);

                        response.Demographics.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesPersonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLStoreMapper();

                        BOStore bo = new BOStore();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        ApiStoreResponseModel response = mapper.MapBOToModel(bo);

                        response.BusinessEntityID.Should().Be(1);
                        response.Demographics.Should().Be("A");
                        response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
                        response.Name.Should().Be("A");
                        response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        response.SalesPersonID.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLStoreMapper();

                        BOStore bo = new BOStore();

                        bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), 1);
                        List<ApiStoreResponseModel> response = mapper.MapBOToModel(new List<BOStore>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>05f639ab559e2d0b4c02b773b6d1dd10</Hash>
</Codenesium>*/