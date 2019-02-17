using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>8ecfbe08fe42ecc11818dd6e780a7564</Hash>
</Codenesium>*/