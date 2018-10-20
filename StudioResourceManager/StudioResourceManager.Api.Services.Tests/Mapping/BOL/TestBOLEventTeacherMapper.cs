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
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLEventTeacherMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLEventTeacherMapper();
			ApiEventTeacherRequestModel model = new ApiEventTeacherRequestModel();
			model.SetProperties(1, true);
			BOEventTeacher response = mapper.MapModelToBO(1, model);

			response.TeacherId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLEventTeacherMapper();
			BOEventTeacher bo = new BOEventTeacher();
			bo.SetProperties(1, 1, true);
			ApiEventTeacherResponseModel response = mapper.MapBOToModel(bo);

			response.EventId.Should().Be(1);
			response.TeacherId.Should().Be(1);
			response.IsDeleted.Should().Be(true);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLEventTeacherMapper();
			BOEventTeacher bo = new BOEventTeacher();
			bo.SetProperties(1, 1, true);
			List<ApiEventTeacherResponseModel> response = mapper.MapBOToModel(new List<BOEventTeacher>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1ed5ab0525188ade9ba99f736d80aee9</Hash>
</Codenesium>*/