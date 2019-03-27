using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallStatus")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallStatusMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallStatusMapper();
			ApiCallStatusServerRequestModel model = new ApiCallStatusServerRequestModel();
			model.SetProperties("A");
			CallStatus response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallStatusMapper();
			CallStatus item = new CallStatus();
			item.SetProperties(1, "A");
			ApiCallStatusServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallStatusMapper();
			CallStatus item = new CallStatus();
			item.SetProperties(1, "A");
			List<ApiCallStatusServerResponseModel> response = mapper.MapEntityToModel(new List<CallStatus>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>1eaf6f43af295b312ac5aef6525d857a</Hash>
</Codenesium>*/