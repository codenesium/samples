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
			model.SetProperties("A", "A", 1);
			User response = mapper.MapModelToEntity(1, model);

			response.Email.Should().Be("A");
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A", 1);
			ApiUserServerResponseModel response = mapper.MapEntityToModel(item);

			response.Email.Should().Be("A");
			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.SubscriptionId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A", 1);
			List<ApiUserServerResponseModel> response = mapper.MapEntityToModel(new List<User>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>6e2fef4e50f8cd7e5d5b6bf37828cc94</Hash>
</Codenesium>*/