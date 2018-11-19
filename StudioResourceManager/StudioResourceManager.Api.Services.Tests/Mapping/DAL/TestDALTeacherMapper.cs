using FluentAssertions;
using StudioResourceManagerNS.Api.DataAccess;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace StudioResourceManagerNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Teacher")]
	[Trait("Area", "DALMapper")]
	public class TestDALTeacherMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALTeacherMapper();
			var bo = new BOTeacher();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", "A", "A", 1);

			Teacher response = mapper.MapBOToEF(bo);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALTeacherMapper();
			Teacher entity = new Teacher();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);

			BOTeacher response = mapper.MapEFToBO(entity);

			response.Birthday.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Phone.Should().Be("A");
			response.UserId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALTeacherMapper();
			Teacher entity = new Teacher();
			entity.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", 1, "A", "A", 1);

			List<BOTeacher> response = mapper.MapEFToBO(new List<Teacher>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>adeb1b8a99229816d8cead0fb0a1f979</Hash>
</Codenesium>*/