using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Department")]
	[Trait("Area", "DALMapper")]
	public class TestDALDepartmentMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALDepartmentMapper();
			var bo = new BODepartment();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			Department response = mapper.MapBOToEF(bo);

			response.DepartmentID.Should().Be(1);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALDepartmentMapper();
			Department entity = new Department();
			entity.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			BODepartment response = mapper.MapEFToBO(entity);

			response.DepartmentID.Should().Be(1);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALDepartmentMapper();
			Department entity = new Department();
			entity.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");

			List<BODepartment> response = mapper.MapEFToBO(new List<Department>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>23b8dae622ce0cb4688f26d81166be24</Hash>
</Codenesium>*/