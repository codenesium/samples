using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "DeviceAction")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDeviceActionActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDeviceActionMapper();

                        ApiDeviceActionRequestModel model = new ApiDeviceActionRequestModel();

                        model.SetProperties(1, "A", "A");
                        BODeviceAction response = mapper.MapModelToBO(1, model);

                        response.DeviceId.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.@Value.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDeviceActionMapper();

                        BODeviceAction bo = new BODeviceAction();

                        bo.SetProperties(1, 1, "A", "A");
                        ApiDeviceActionResponseModel response = mapper.MapBOToModel(bo);

                        response.DeviceId.Should().Be(1);
                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.@Value.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDeviceActionMapper();

                        BODeviceAction bo = new BODeviceAction();

                        bo.SetProperties(1, 1, "A", "A");
                        List<ApiDeviceActionResponseModel> response = mapper.MapBOToModel(new List<BODeviceAction>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b85812343cb140c0bcb222d7c83fe882</Hash>
</Codenesium>*/