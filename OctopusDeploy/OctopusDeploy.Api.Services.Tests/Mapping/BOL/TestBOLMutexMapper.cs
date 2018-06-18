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
        [Trait("Table", "Mutex")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLMutexActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLMutexMapper();

                        ApiMutexRequestModel model = new ApiMutexRequestModel();

                        model.SetProperties("A");
                        BOMutex response = mapper.MapModelToBO("A", model);

                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLMutexMapper();

                        BOMutex bo = new BOMutex();

                        bo.SetProperties("A", "A");
                        ApiMutexResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.JSON.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLMutexMapper();

                        BOMutex bo = new BOMutex();

                        bo.SetProperties("A", "A");
                        List<ApiMutexResponseModel> response = mapper.MapBOToModel(new List<BOMutex>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>2d6cf455fee915c2211ce8407b5a968b</Hash>
</Codenesium>*/