using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventureWorksNS.Api.Client.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "Person")]
	[Trait("Area", "ApiModel")]
	public class TestApiPersonModelMapper
	{
		[Fact]
		public void MapClientRequestToResponse()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientRequestModel();
			model.SetProperties("A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonClientResponseModel response = mapper.MapClientRequestToResponse(1, model);
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
		public void MapClientResponseToRequest()
		{
			var mapper = new ApiPersonModelMapper();
			var model = new ApiPersonClientResponseModel();
			model.SetProperties(1, "A", "A", 1, "A", "A", "A", DateTime.Parse("1/1/1987 12:00:00 AM"), true, "A", Guid.Parse("8420cdcf-d595-ef65-66e7-dff9f98764da"), "A", "A");
			ApiPersonClientRequestModel response = mapper.MapClientResponseToRequest(model);
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
	}
}

/*<Codenesium>
    <Hash>10056a180b59fae38222b4971bf28ded</Hash>
</Codenesium>*/