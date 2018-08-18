using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "EmployeeDepartmentHistory")]
	[Trait("Area", "DALMapper")]
	public class TestDALEmployeeDepartmentHistoryMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALEmployeeDepartmentHistoryMapper();
			var bo = new BOEmployeeDepartmentHistory();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			EmployeeDepartmentHistory response = mapper.MapBOToEF(bo);

			response.BusinessEntityID.Should().Be(1);
			response.DepartmentID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShiftID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALEmployeeDepartmentHistoryMapper();
			EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			BOEmployeeDepartmentHistory response = mapper.MapEFToBO(entity);

			response.BusinessEntityID.Should().Be(1);
			response.DepartmentID.Should().Be(1);
			response.EndDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.ShiftID.Should().Be(1);
			response.StartDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALEmployeeDepartmentHistoryMapper();
			EmployeeDepartmentHistory entity = new EmployeeDepartmentHistory();
			entity.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1, DateTime.Parse("1/1/1987 12:00:00 AM"));

			List<BOEmployeeDepartmentHistory> response = mapper.MapEFToBO(new List<EmployeeDepartmentHistory>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>56ec714abb878d8adcbb791fbc82748c</Hash>
</Codenesium>*/