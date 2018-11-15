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
	[Trait("Table", "Teacher")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTeacherMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTeacherMapper();
			ApiTeacherServerRequestModel model = new ApiTeacherServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			BOTeacher response = mapper.MapModelToBO(1, model);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTeacherMapper();
			BOTeacher bo = new BOTeacher();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			ApiTeacherServerResponseModel response = mapper.MapBOToModel(bo);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTeacherMapper();
			BOTeacher bo = new BOTeacher();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);
			List<ApiTeacherServerResponseModel> response = mapper.MapBOToModel(new List<BOTeacher>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a540ca450d6be81972a76de1bee41d86</Hash>
</Codenesium>*/