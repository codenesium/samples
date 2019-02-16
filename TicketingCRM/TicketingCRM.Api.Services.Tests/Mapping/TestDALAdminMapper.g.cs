using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using Xunit;

namespace TicketingCRMNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "DALMapper")]
	public class TestDALAdminMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALAdminMapper();
			ApiAdminServerRequestModel model = new ApiAdminServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			Admin response = mapper.MapModelToEntity(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALAdminMapper();
			Admin item = new Admin();
			item.SetProperties(1, "A", "A", "A", "A", "A", "A");
			ApiAdminServerResponseModel response = mapper.MapEntityToModel(item);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALAdminMapper();
			Admin item = new Admin();
			item.SetProperties(1, "A", "A", "A", "A", "A", "A");
			List<ApiAdminServerResponseModel> response = mapper.MapEntityToModel(new List<Admin>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c4dae3531e95f892a7479607538029ea</Hash>
</Codenesium>*/