using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventTeacher")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventTeacherMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEventTeacherMapper();
			ApiEventTeacherServerRequestModel model = new ApiEventTeacherServerRequestModel();
			model.SetProperties(1);
			EventTeacher response = mapper.MapModelToEntity(1, model);

			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEventTeacherMapper();
			EventTeacher item = new EventTeacher();
			item.SetProperties(1, 1);
			ApiEventTeacherServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.TeacherId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEventTeacherMapper();
			EventTeacher item = new EventTeacher();
			item.SetProperties(1, 1);
			List<ApiEventTeacherServerResponseModel> response = mapper.MapEntityToModel(new List<EventTeacher>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>95e2c6ca22a6cf3b4df2d12992ec80f9</Hash>
</Codenesium>*/