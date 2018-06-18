using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "ChainStatus")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLChainStatusActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLChainStatusMapper();

                        ApiChainStatusRequestModel model = new ApiChainStatusRequestModel();

                        model.SetProperties("A");
                        BOChainStatus response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLChainStatusMapper();

                        BOChainStatus bo = new BOChainStatus();

                        bo.SetProperties(1, "A");
                        ApiChainStatusResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLChainStatusMapper();

                        BOChainStatus bo = new BOChainStatus();

                        bo.SetProperties(1, "A");
                        List<ApiChainStatusResponseModel> response = mapper.MapBOToModel(new List<BOChainStatus>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>580c8daf66997980f8ee3f01732dc737</Hash>
</Codenesium>*/