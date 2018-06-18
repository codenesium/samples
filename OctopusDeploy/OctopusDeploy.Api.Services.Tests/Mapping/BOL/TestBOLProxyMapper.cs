using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Proxy")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLProxyActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLProxyMapper();

                        ApiProxyRequestModel model = new ApiProxyRequestModel();

                        model.SetProperties("A", "A");
                        BOProxy response = mapper.MapModelToBO("A", model);

                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLProxyMapper();

                        BOProxy bo = new BOProxy();

                        bo.SetProperties("A", "A", "A");
                        ApiProxyResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLProxyMapper();

                        BOProxy bo = new BOProxy();

                        bo.SetProperties("A", "A", "A");
                        List<ApiProxyResponseModel> response = mapper.MapBOToModel(new List<BOProxy>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>9252f8b886a1147d1ae1a2843b03b171</Hash>
</Codenesium>*/