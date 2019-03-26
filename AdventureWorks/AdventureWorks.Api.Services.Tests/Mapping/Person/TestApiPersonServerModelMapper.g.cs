using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonServerModelMapper
	{
		[Fact]
		public void MapServerRequestToResponse()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonServerResponseModel response = mapper.MapServerRequestToResponse(1, model);
			response.Should().NotBeNull();
			response.AdditionalContactInfo.Should().Be("A");
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void MapServerResponseToRequest()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerResponseModel();
			model.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonServerRequestModel response = mapper.MapServerResponseToRequest(model);
			response.Should().NotBeNull();
			response.AdditionalContactInfo.Should().Be("A");
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
			response.Title.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiPersonServerModelMapper();
			var model = new ApiPersonServerRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");

			JsonPatchDocument<ApiPersonServerRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiPersonServerRequestModel();
			patch.ApplyTo(response);
			response.AdditionalContactInfo.Should().Be("A");
			response.Demographic.Should().Be("A");
			response.EmailPromotion.Should().Be(1);
			response.FirstName.Should().Be("A");
			response.LastName.Should().Be("A");
			response.MiddleName.Should().Be("A");
			response.ModifiedDate.Should().Be(DateTime.Parse("1/1/1987 12:00:00 AM"));
			response.NameStyle.Should().Be(true);
			response.PersonType.Should().Be("A");
			response.Rowguid.Should().Be(Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"));
			response.Suffix.Should().Be("A");
			response.Title.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>179e254b9fdf49028cfbb16fb887279d</Hash>
</Codenesium>*/