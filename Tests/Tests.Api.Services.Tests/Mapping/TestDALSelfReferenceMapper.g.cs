using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using Xunit;

namespace TestsNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "SelfReference")]
	[Trait("Area", "DALMapper")]
	public class TestDALSelfReferenceMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALSelfReferenceMapper();
			ApiSelfReferenceServerRequestModel model = new ApiSelfReferenceServerRequestModel();
			model.SetProperties(1, 1);
			SelfReference response = mapper.MapModelToEntity(1, model);

			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALSelfReferenceMapper();
			SelfReference item = new SelfReference();
			item.SetProperties(1, 1, 1);
			ApiSelfReferenceServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.SelfReferenceId.Should().Be(1);
			response.SelfReferenceId2.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALSelfReferenceMapper();
			SelfReference item = new SelfReference();
			item.SetProperties(1, 1, 1);
			List<ApiSelfReferenceServerResponseModel> response = mapper.MapEntityToModel(new List<SelfReference>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f2c6459f3e1a3b159b2669ee78443969</Hash>
</Codenesium>*/