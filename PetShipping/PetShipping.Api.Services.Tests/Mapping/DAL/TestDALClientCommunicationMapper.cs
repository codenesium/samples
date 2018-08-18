using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "ClientCommunication")]
	[Trait("Area", "DALMapper")]
	public class TestDALClientCommunicationMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALClientCommunicationMapper();
			var bo = new BOClientCommunication();
			bo.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, "A");

			ClientCommunication response = mapper.MapBOToEF(bo);

			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALClientCommunicationMapper();
			ClientCommunication entity = new ClientCommunication();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			BOClientCommunication response = mapper.MapEFToBO(entity);

			response.ClientId.Should().Be(1);
			response.DateCreated.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Notes.Should().Be("A");
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALClientCommunicationMapper();
			ClientCommunication entity = new ClientCommunication();
			entity.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), 1, 1, "A");

			List<BOClientCommunication> response = mapper.MapEFToBO(new List<ClientCommunication>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ef309a246e7ee5006856c666bb60c3dc</Hash>
</Codenesium>*/