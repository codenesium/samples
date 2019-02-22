using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallDisposition")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallDispositionMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallDispositionMapper();
			ApiCallDispositionServerRequestModel model = new ApiCallDispositionServerRequestModel();
			model.SetProperties("A");
			CallDisposition response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallDispositionMapper();
			CallDisposition item = new CallDisposition();
			item.SetProperties(1, "A");
			ApiCallDispositionServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallDispositionMapper();
			CallDisposition item = new CallDisposition();
			item.SetProperties(1, "A");
			List<ApiCallDispositionServerResponseModel> response = mapper.MapEntityToModel(new List<CallDisposition>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>b7295cce053ff55a68e4d46b5628d7af</Hash>
</Codenesium>*/