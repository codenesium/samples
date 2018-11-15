using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Client")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLClientMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLClientMapper();
			ApiClientServerRequestModel model = new ApiClientServerRequestModel();
			model.SetProperties("A", "A", "A", "A", "A");
			BOClient response = mapper.MapModelToBO(1, model);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLClientMapper();
			BOClient bo = new BOClient();
			bo.SetProperties(1, "A", "A", "A", "A", "A");
			ApiClientServerResponseModel response = mapper.MapBOToModel(bo);

			response.Email.Should().Be("A");
			response.FirstName.Should().Be("A");
			response.Id.Should().Be(1);
			response.LastName.Should().Be("A");
			response.Note.Should().Be("A");
			response.Phone.Should().Be("A");
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLClientMapper();
			BOClient bo = new BOClient();
			bo.SetProperties(1, "A", "A", "A", "A", "A");
			List<ApiClientServerResponseModel> response = mapper.MapBOToModel(new List<BOClient>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>c3d5af3bad8d6f379acff3cc5fd6777f</Hash>
</Codenesium>*/