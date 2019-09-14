using FluentAssertions;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "DALMapper")]
	public class TestDALStudentMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALStudentMapper();
			ApiStudentServerRequestModel model = new ApiStudentServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			Student response = mapper.MapModelToEntity(1, model);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.EmailRemindersEnabled.Should().Be(true);
			response.FamilyId.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.IsAdult.Should().Be(true);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.SmsRemindersEnabled.Should().Be(true);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALStudentMapper();
			Student item = new Student();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			ApiStudentServerResponseModel response = mapper.MapEntityToModel(item);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.EmailRemindersEnabled.Should().Be(true);
			response.FamilyId.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.IsAdult.Should().Be(true);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.SmsRemindersEnabled.Should().Be(true);
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALStudentMapper();
			Student item = new Student();
			item.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);
			List<ApiStudentServerResponseModel> response = mapper.MapEntityToModel(new List<Student>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>d4d3aedee6322167750d2ac0259e8e44</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/