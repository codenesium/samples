using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
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
			model.SetProperties("A", "A");
			User response = mapper.MapModelToEntity(1, model);

			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A");
			ApiUserServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALUserMapper();
			User item = new User();
			item.SetProperties(1, "A", "A");
			List<ApiUserServerResponseModel> response = mapper.MapEntityToModel(new List<User>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>78188089208e0c103cf665ba4282ef8c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/