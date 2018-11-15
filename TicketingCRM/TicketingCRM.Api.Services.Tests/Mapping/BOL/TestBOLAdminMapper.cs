using FluentAssertions;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;
using TicketingCRMNS.Api.Services;
using Xunit;

namespace TicketingCRMNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Admin")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLAdminMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLAdminMapper();
			ApiAdminServerRequestModel model = new ApiAdminServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A", "A");
			BOAdmin response = mapper.MapModelToBO(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLAdminMapper();
			BOAdmin bo = new BOAdmin();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A");
			ApiAdminServerResponseModel response = mapper.MapBOToModel(bo);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Password.Should().Be("A");
			response.Phone.Should().Be("A");
			response.Username.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLAdminMapper();
			BOAdmin bo = new BOAdmin();
			bo.SetProperties(1, "A", "A", "A", "A", "A", "A");
			List<ApiAdminServerResponseModel> response = mapper.MapBOToModel(new List<BOAdmin>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>2cd40f678546c4657fd9c27bc9fd9939</Hash>
</Codenesium>*/