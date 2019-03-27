using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallAssignment")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallAssignmentMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallAssignmentMapper();
			ApiCallAssignmentServerRequestModel model = new ApiCallAssignmentServerRequestModel();
			model.SetProperties(1, 1);
			CallAssignment response = mapper.MapModelToEntity(1, model);

			response.CallId.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallAssignmentMapper();
			CallAssignment item = new CallAssignment();
			item.SetProperties(1, 1, 1);
			ApiCallAssignmentServerResponseModel response = mapper.MapEntityToModel(item);

			response.CallId.Should().Be(1);
			response.Id.Should().Be(1);
			response.UnitId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallAssignmentMapper();
			CallAssignment item = new CallAssignment();
			item.SetProperties(1, 1, 1);
			List<ApiCallAssignmentServerResponseModel> response = mapper.MapEntityToModel(new List<CallAssignment>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>328c1348de3204643253e2c9ff337a7e</Hash>
</Codenesium>*/