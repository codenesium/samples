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
	[Trait("Table", "Rate")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLRateMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLRateMapper();
			ApiRateRequestModel model = new ApiRateRequestModel();
			model.SetProperties(1m, 1, 1, true);
			BORate response = mapper.MapModelToBO(1, model);

			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLRateMapper();
			BORate bo = new BORate();
			bo.SetProperties(1, 1m, 1, 1, true);
			ApiRateResponseModel response = mapper.MapBOToModel(bo);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLRateMapper();
			BORate bo = new BORate();
			bo.SetProperties(1, 1m, 1, 1, true);
			List<ApiRateResponseModel> response = mapper.MapBOToModel(new List<BORate>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b3f1513c5d843e03167bb67543059a04</Hash>
</Codenesium>*/