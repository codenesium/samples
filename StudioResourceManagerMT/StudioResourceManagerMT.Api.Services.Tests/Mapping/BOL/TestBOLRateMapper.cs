using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
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
    <Hash>314e0ea78bde6f1cd9183540dc05e79d</Hash>
</Codenesium>*/