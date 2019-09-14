using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Rate")]
	[Trait("Area", "DALMapper")]
	public class TestDALRateMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALRateMapper();
			ApiRateServerRequestModel model = new ApiRateServerRequestModel();
			model.SetProperties(1m, 1, 1);
			Rate response = mapper.MapModelToEntity(1, model);

			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALRateMapper();
			Rate item = new Rate();
			item.SetProperties(1, 1m, 1, 1);
			ApiRateServerResponseModel response = mapper.MapEntityToModel(item);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALRateMapper();
			Rate item = new Rate();
			item.SetProperties(1, 1m, 1, 1);
			List<ApiRateServerResponseModel> response = mapper.MapEntityToModel(new List<Rate>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>e7d6342c5e696c350c9d2ce41e239225</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/