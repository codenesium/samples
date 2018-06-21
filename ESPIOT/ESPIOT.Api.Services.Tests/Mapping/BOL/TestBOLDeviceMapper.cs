using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Device")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLDeviceMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLDeviceMapper();
                        ApiDeviceRequestModel model = new ApiDeviceRequestModel();
                        model.SetProperties("A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        BODevice response = mapper.MapModelToBO(1, model);

                        response.Name.Should().Be("A");
                        response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLDeviceMapper();
                        BODevice bo = new BODevice();
                        bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        ApiDeviceResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be(1);
                        response.Name.Should().Be("A");
                        response.PublicId.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLDeviceMapper();
                        BODevice bo = new BODevice();
                        bo.SetProperties(1, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
                        List<ApiDeviceResponseModel> response = mapper.MapBOToModel(new List<BODevice>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>ae1e3932376bec93f3fd0050a4839d9d</Hash>
</Codenesium>*/