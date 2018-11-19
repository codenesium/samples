using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "User")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLUserMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLUserMapper();
			ApiUserServerRequestModel model = new ApiUserServerRequestModel();
			model.SetProperties("A", "A");
			BOUser response = mapper.MapModelToBO(1, model);

			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLUserMapper();
			BOUser bo = new BOUser();
			bo.SetProperties(1, "A", "A");
			ApiUserServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Password.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLUserMapper();
			BOUser bo = new BOUser();
			bo.SetProperties(1, "A", "A");
			List<ApiUserServerResponseModel> response = mapper.MapBOToModel(new List<BOUser>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>4c7a57fa55fa72ebbc91fbe9ee80aa9b</Hash>
</Codenesium>*/