using FluentAssertions;
using StudioResourceManagerMTNS.Api.DataAccess;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerMTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Student")]
	[Trait("Area", "DALMapper")]
	public class TestDALStudentMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALStudentMapper();
			var bo = new BOStudent();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", true, "A", "A", true, 1);

			Student response = mapper.MapBOToEF(bo);

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
		public void MapEFToBO()
		{
			var mapper = new DALStudentMapper();
			Student entity = new Student();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", 1, true, "A", "A", true, 1);

			BOStudent response = mapper.MapEFToBO(entity);

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
		public void MapEFToBOList()
		{
			var mapper = new DALStudentMapper();
			Student entity = new Student();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", true, 1, "A", 1, true, "A", "A", true, 1);

			List<BOStudent> response = mapper.MapEFToBO(new List<Student>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>926e840be75dba17261cafccacbd4c72</Hash>
</Codenesium>*/