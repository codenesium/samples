using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using AdventureWorksNS.Api.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Password")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLPasswordMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLPasswordMapper();
			ApiPasswordServerRequestModel model = new ApiPasswordServerRequestModel();
			model.SetProperties(DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			BOPassword response = mapper.MapModelToBO(1, model);

			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PasswordHash.Should().Be("A");
			response.PasswordSalt.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLPasswordMapper();
			BOPassword bo = new BOPassword();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			ApiPasswordServerResponseModel response = mapper.MapBOToModel(bo);

			response.BusinessEntityID.Should().Be(1);
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.PasswordHash.Should().Be("A");
			response.PasswordSalt.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLPasswordMapper();
			BOPassword bo = new BOPassword();
			bo.SetProperties(1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			List<ApiPasswordServerResponseModel> response = mapper.MapBOToModel(new List<BOPassword>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>9a5a7ab7cfb0f063d38bbccbed3d701d</Hash>
</Codenesium>*/