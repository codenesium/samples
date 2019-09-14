using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallType")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallTypeMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallTypeMapper();
			ApiCallTypeServerRequestModel model = new ApiCallTypeServerRequestModel();
			model.SetProperties("A");
			CallType response = mapper.MapModelToEntity(1, model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallTypeMapper();
			CallType item = new CallType();
			item.SetProperties(1, "A");
			ApiCallTypeServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallTypeMapper();
			CallType item = new CallType();
			item.SetProperties(1, "A");
			List<ApiCallTypeServerResponseModel> response = mapper.MapEntityToModel(new List<CallType>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>961c4401851a0fc3d1ec38c0addc0fae</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/