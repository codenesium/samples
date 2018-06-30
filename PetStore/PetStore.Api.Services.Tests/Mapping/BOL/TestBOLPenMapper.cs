using FluentAssertions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using PetStoreNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetStoreNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Pen")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPenMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPenMapper();
                        ApiPenRequestModel model = new ApiPenRequestModel();
                        model.SetProperties("A");
                        BOPen response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPenMapper();
                        BOPen bo = new BOPen();
                        bo.SetProperties(1, "A");
                        ApiPenResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPenMapper();
                        BOPen bo = new BOPen();
                        bo.SetProperties(1, "A");
                        List<ApiPenResponseModel> response = mapper.MapBOToModel(new List<BOPen>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>0ee0de980218f8a6a3eca1b411945166</Hash>
</Codenesium>*/