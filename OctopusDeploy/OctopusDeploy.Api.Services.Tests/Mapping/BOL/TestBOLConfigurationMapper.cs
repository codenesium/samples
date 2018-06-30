using FluentAssertions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Configuration")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLConfigurationMapper
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
    <Hash>59cd3366b1b1b3a9d1b3ce1043b4ed1b</Hash>
</Codenesium>*/