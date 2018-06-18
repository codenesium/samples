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
        [Trait("Table", "Subscription")]
        [Trait("Area", "BOLMapper")]
        public class TestBOLSubscriptionActionMapper
        {
                [Fact]
                public void MapModelToBO()
                {
                        var mapper = new BOLSubscriptionMapper();

                        ApiSubscriptionRequestModel model = new ApiSubscriptionRequestModel();

                        model.SetProperties(true, "A", "A", "A");
                        BOSubscription response = mapper.MapModelToBO("A", model);

                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModel()
                {
                        var mapper = new BOLSubscriptionMapper();

                        BOSubscription bo = new BOSubscription();

                        bo.SetProperties("A", true, "A", "A", "A");
                        ApiSubscriptionResponseModel response = mapper.MapBOToModel(bo);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapBOToModelList()
                {
                        var mapper = new BOLSubscriptionMapper();

                        BOSubscription bo = new BOSubscription();

                        bo.SetProperties("A", true, "A", "A", "A");
                        List<ApiSubscriptionResponseModel> response = mapper.MapBOToModel(new List<BOSubscription>() { { bo } });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>eea2cc6020a6d5d65b68d00d2cdc4c6f</Hash>
</Codenesium>*/