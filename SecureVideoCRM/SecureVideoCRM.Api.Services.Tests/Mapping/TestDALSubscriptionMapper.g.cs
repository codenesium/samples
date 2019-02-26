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
			model.SetProperties("A");
			Subscription response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSubscriptionMapper();
			Subscription item = new Subscription();
			item.SetProperties(1, "A");
			ApiSubscriptionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSubscriptionMapper();
			Subscription item = new Subscription();
			item.SetProperties(1, "A");
			List<ApiSubscriptionServerResponseModel> response = mapper.MapEntityToModel(new List<Subscription>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>75d5b327d1f7f666c12ad45a5483e0c6</Hash>
</Codenesium>*/