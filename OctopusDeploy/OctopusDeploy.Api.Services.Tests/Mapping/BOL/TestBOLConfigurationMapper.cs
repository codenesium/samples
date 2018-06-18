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
        [Trait("Table", "Configuration")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLConfigurationActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLConfigurationMapper();

                        ApiConfigurationRequestModel model = new ApiConfigurationRequestModel();

                        model.SetProperties("A");
                        BOConfiguration response = mapper.MapModelToBO("A", model);

                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLConfigurationMapper();

                        BOConfiguration bo = new BOConfiguration();

                        bo.SetProperties("A", "A");
                        ApiConfigurationResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLConfigurationMapper();

                        BOConfiguration bo = new BOConfiguration();

                        bo.SetProperties("A", "A");
                        List<ApiConfigurationResponseModel> response = mapper.MapBOToModel(new List<BOConfiguration>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>1773e378c68287b8e2190cf8d9f3475e</Hash>
</Codenesium>*/