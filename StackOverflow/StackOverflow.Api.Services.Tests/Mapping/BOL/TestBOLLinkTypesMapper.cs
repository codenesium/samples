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
        [Trait("Table", "LinkTypes")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLinkTypesMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLinkTypesMapper();
                        ApiLinkTypesRequestModel model = new ApiLinkTypesRequestModel();
                        model.SetProperties("A");
                        BOLinkTypes response = mapper.MapModelToBO(1, model);

                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLinkTypesMapper();
                        BOLinkTypes bo = new BOLinkTypes();
                        bo.SetProperties(1, "A");
                        ApiLinkTypesResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLinkTypesMapper();
                        BOLinkTypes bo = new BOLinkTypes();
                        bo.SetProperties(1, "A");
                        List<ApiLinkTypesResponseModel> response = mapper.MapBOToModel(new List<BOLinkTypes>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>4c3743305b33aae62a895a2b839bcd1f</Hash>
</Codenesium>*/