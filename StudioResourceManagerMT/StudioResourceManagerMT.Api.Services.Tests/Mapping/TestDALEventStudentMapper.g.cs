using FluentAssertions;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EventStudent")]
	[Trait("Area", "DALMapper")]
	public class TestDALEventStudentMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALEventStudentMapper();
			ApiEventStudentServerRequestModel model = new ApiEventStudentServerRequestModel();
			model.SetProperties(1);
			EventStudent response = mapper.MapModelToEntity(1, model);

			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent item = new EventStudent();
			item.SetProperties(1, 1);
			ApiEventStudentServerResponseModel response = mapper.MapEntityToModel(item);

			response.EventId.Should().Be(1);
			response.StudentId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALEventStudentMapper();
			EventStudent item = new EventStudent();
			item.SetProperties(1, 1);
			List<ApiEventStudentServerResponseModel> response = mapper.MapEntityToModel(new List<EventStudent>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>069aa948c2d13004ecbd4450ffd4561c</Hash>
</Codenesium>*/