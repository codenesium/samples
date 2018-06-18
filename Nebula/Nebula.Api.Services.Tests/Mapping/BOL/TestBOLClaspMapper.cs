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
        [Trait("Table", "Clasp")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLClaspActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLClaspMapper();

                        ApiClaspRequestModel model = new ApiClaspRequestModel();

                        model.SetProperties(1, 1);
                        BOClasp response = mapper.MapModelToBO(1, model);

                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLClaspMapper();

                        BOClasp bo = new BOClasp();

                        bo.SetProperties(1, 1, 1);
                        ApiClaspResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.NextChainId.Should().Be(1);
                        response.PreviousChainId.Should().Be(1);
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLClaspMapper();

                        BOClasp bo = new BOClasp();

                        bo.SetProperties(1, 1, 1);
                        List<ApiClaspResponseModel> response = mapper.MapBOToModel(new List<BOClasp>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>080fb8b19df7cf9639460fc5e9381a21</Hash>
</Codenesium>*/