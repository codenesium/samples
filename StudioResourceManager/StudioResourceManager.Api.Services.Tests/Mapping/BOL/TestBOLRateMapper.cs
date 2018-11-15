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
			ApiRateServerRequestModel model = new ApiRateServerRequestModel();
			model.SetProperties(1m, 1, 1);
			BORate response = mapper.MapModelToBO(1, model);

			response.AmountPerMinute.Should().Be(1m);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLRateMapper();
			BORate bo = new BORate();
			bo.SetProperties(1, 1m, 1, 1);
			ApiRateServerResponseModel response = mapper.MapBOToModel(bo);

			response.AmountPerMinute.Should().Be(1m);
			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.TeacherSkillId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLRateMapper();
			BORate bo = new BORate();
			bo.SetProperties(1, 1m, 1, 1);
			List<ApiRateServerResponseModel> response = mapper.MapBOToModel(new List<BORate>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>90637842901b53b88ec109f38694488c</Hash>
</Codenesium>*/