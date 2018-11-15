using AdventureWorksNS.Api.Contracts;
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
	[Trait("Area", "BOLMapper")]
	public class TestBOLDepartmentMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLDepartmentMapper();
			ApiDepartmentServerRequestModel model = new ApiDepartmentServerRequestModel();
			model.SetProperties("A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			BODepartment response = mapper.MapModelToBO(1, model);

			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLDepartmentMapper();
			BODepartment bo = new BODepartment();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			ApiDepartmentServerResponseModel response = mapper.MapBOToModel(bo);

			response.DepartmentID.Should().Be(1);
			response.GroupName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLDepartmentMapper();
			BODepartment bo = new BODepartment();
			bo.SetProperties(1, "A", DateTime.Parse("1/1/1987 12:00:00 AM"), "A");
			List<ApiDepartmentServerResponseModel> response = mapper.MapBOToModel(new List<BODepartment>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>384fea0945827edcb2a4a90043e13fd2</Hash>
</Codenesium>*/