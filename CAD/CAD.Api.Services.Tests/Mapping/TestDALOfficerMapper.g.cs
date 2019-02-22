using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CADNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Officer")]
	[Trait("Area", "DALMapper")]
	public class TestDALOfficerMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALOfficerMapper();
			ApiOfficerServerRequestModel model = new ApiOfficerServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			Officer response = mapper.MapModelToEntity(1, model);

			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALOfficerMapper();
			Officer item = new Officer();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			ApiOfficerServerResponseModel response = mapper.MapEntityToModel(item);

			response.Badge.Should().Be("A");
			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALOfficerMapper();
			Officer item = new Officer();
			item.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiOfficerServerResponseModel> response = mapper.MapEntityToModel(new List<Officer>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>f5927f5dfc2db8023c241e78c80deeef</Hash>
</Codenesium>*/