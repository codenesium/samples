using FluentAssertions;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StackOverflowNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "PostHistoryTypes")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLPostHistoryTypesMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLPostHistoryTypesMapper();
                        ApiPostHistoryTypesRequestModel model = new ApiPostHistoryTypesRequestModel();
                        model.SetProperties("A");
                        BOPostHistoryTypes response = mapper.MapModelToBO(1, model);

                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLPostHistoryTypesMapper();
                        BOPostHistoryTypes bo = new BOPostHistoryTypes();
                        bo.SetProperties(1, "A");
                        ApiPostHistoryTypesResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLPostHistoryTypesMapper();
                        BOPostHistoryTypes bo = new BOPostHistoryTypes();
                        bo.SetProperties(1, "A");
                        List<ApiPostHistoryTypesResponseModel> response = mapper.MapBOToModel(new List<BOPostHistoryTypes>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>58dff328e00d906c582dffe5b6769245</Hash>
</Codenesium>*/