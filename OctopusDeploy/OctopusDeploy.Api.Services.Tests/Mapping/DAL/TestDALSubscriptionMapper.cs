using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Services.Tests
{
        [Trait("Type", "Unit")]
        [Trait("Table", "Subscription")]
        [Trait("Area", "DALMapper")]
        public class TestDALSubscriptionActionMapper
        {
                [Fact]
                public void MapBOToEF()
                {
                        var mapper = new DALSubscriptionMapper();

                        var bo = new BOSubscription();

                        bo.SetProperties("A", true, "A", "A", "A");

                        Subscription response = mapper.MapBOToEF(bo);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapEFToBO()
                {
                        var mapper = new DALSubscriptionMapper();

                        Subscription entity = new Subscription();

                        entity.SetProperties("A", true, "A", "A", "A");

                        BOSubscription  response = mapper.MapEFToBO(entity);

                        response.Id.Should().Be("A");
                        response.IsDisabled.Should().Be(true);
                        response.JSON.Should().Be("A");
                        response.Name.Should().Be("A");
                        response.Type.Should().Be("A");
                }

                [Fact]
                public void MapEFToBOList()
                {
                        var mapper = new DALSubscriptionMapper();

                        Subscription entity = new Subscription();

                        entity.SetProperties("A", true, "A", "A", "A");

                        List<BOSubscription> response = mapper.MapEFToBO(new List<Subscription>() { entity });

                        response.Count.Should().Be(1);
                }
        }
}

/*<Codenesium>
    <Hash>b27b612f27e0cca4930ab26f726955fd</Hash>
</Codenesium>*/