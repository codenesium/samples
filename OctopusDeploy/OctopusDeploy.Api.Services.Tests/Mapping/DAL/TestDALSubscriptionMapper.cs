using FluentAssertions;
using OctopusDeployNS.Api.DataAccess;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace OctopusDeployNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "DALMapper")]
	public class TestDALSubscriptionMapper
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

			BOSubscription response = mapper.MapEFToBO(entity);

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
    <Hash>ae394c604d9c342636776f31eb18000f</Hash>
</Codenesium>*/