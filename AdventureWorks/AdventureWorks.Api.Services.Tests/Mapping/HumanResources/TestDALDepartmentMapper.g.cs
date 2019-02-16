using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Department")]
	[Trait("Area", "DALMapper")]
	public class TestDALDepartmentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new DALDepartmentMapper();
			ApiDepartmentServerRequestModel model = new ApiDepartmentServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			Department response = mapper.MapModelToBO(1, model);

			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new DALDepartmentMapper();
			Department item = new Department();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiDepartmentServerResponseModel response = mapper.MapBOToModel(item);

			response.DepartmentID.Should().Be(1);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new DALDepartmentMapper();
			Department item = new Department();
			item.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiDepartmentServerResponseModel> response = mapper.MapBOToModel(new List<Department>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>a5283d9bcfc7e93e11eec8d7d4bf6193</Hash>
</Codenesium>*/