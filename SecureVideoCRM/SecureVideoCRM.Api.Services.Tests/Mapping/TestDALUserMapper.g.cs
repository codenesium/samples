using FluentAssertions;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace SecureVideoCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "DALMapper")]
	public class TestDALUserMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALUserMapper();
			ApiUserServerRequestModel model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A", "A", 1);
			User response = mapper.MapModelToEntity(1, model);

			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A", "A", 1);
			ApiUserServerResponseModel response = mapper.MapEntityToModel(item);

			response.Email.Should().Be("A");
			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.StripeCustomerId.Should().Be("A");
			response.SubscriptionTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A", "A", 1);
			List<ApiUserServerResponseModel> response = mapper.MapEntityToModel(new List<User>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>afffb49a3cb3a644ef39cd873e9cbfc8</Hash>
</Codenesium>*/