using FluentAssertions;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Subscription")]
	[Trait("Area", "DALMapper")]
	public class TestDALSubscriptionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSubscriptionMapper();
			ApiSubscriptionServerRequestModel model = new ApiSubscriptionServerRequestModel();
			model.SetProperties("A", "A");
			Subscription response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
			response.StripePlanName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSubscriptionMapper();
			Subscription item = new Subscription();
			item.SetProperties(1, "A", "A");
			ApiSubscriptionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.StripePlanName.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSubscriptionMapper();
			Subscription item = new Subscription();
			item.SetProperties(1, "A", "A");
			List<ApiSubscriptionServerResponseModel> response = mapper.MapEntityToModel(new List<Subscription>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>46491014ba0acb194fb663f5d7807324</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/