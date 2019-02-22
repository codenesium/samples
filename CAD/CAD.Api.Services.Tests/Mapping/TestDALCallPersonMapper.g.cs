using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "CallPerson")]
	[Trait("Area", "DALMapper")]
	public class TestDALCallPersonMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALCallPersonMapper();
			ApiCallPersonServerRequestModel model = new ApiCallPersonServerRequestModel();
			model.SetProperties("A", 1, 1);
			CallPerson response = mapper.MapModelToEntity(1, model);

			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALCallPersonMapper();
			CallPerson item = new CallPerson();
			item.SetProperties(1, "A", 1, 1);
			ApiCallPersonServerResponseModel response = mapper.MapEntityToModel(item);

			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PersonId.Should().Be(1);
			response.PersonTypeId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALCallPersonMapper();
			CallPerson item = new CallPerson();
			item.SetProperties(1, "A", 1, 1);
			List<ApiCallPersonServerResponseModel> response = mapper.MapEntityToModel(new List<CallPerson>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>da3a2e7f045424885941c04eebecf814</Hash>
</Codenesium>*/