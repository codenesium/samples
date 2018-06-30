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
        [Trait("Table", "Lifecycle")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLLifecycleMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLLifecycleMapper();
                        ApiLifecycleRequestModel model = new ApiLifecycleRequestModel();
                        model.SetProperties(BitConverter.GetBytes(1), "A", "A");
                        BOLifecycle response = mapper.MapModelToBO("A", model);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLLifecycleMapper();
                        BOLifecycle bo = new BOLifecycle();
                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        ApiLifecycleResponseModel response = mapper.MapBOToModel(bo);

                        response.DataVersion.Should().BeEquivalentTo(BitConverter.GetBytes(1));
                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLLifecycleMapper();
                        BOLifecycle bo = new BOLifecycle();
                        bo.SetProperties("A", BitConverter.GetBytes(1), "A", "A");
                        List<ApiLifecycleResponseModel> response = mapper.MapBOToModel(new List<BOLifecycle>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>974abcabe81914e97387ec2a3af39936</Hash>
</Codenesium>*/