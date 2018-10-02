using FluentAssertions;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using Xunit;

namespace TicketingCRMNS.Api.Contracts.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TransactionStatu")]
	[Trait("Area", "ApiModel")]
	public class TestApiTransactionStatuModelMapper
	{
		[Fact]
		public void MapRequestToResponse()
		{
			var mapper = new ApiTransactionStatuModelMapper();
			var model = new ApiTransactionStatuRequestModel();
			model.SetProperties("A");
			ApiTransactionStatuResponseModel response = mapper.MapRequestToResponse(1, model);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
		}

		[Fact]
		public void MapResponseToRequest()
		{
			var mapper = new ApiTransactionStatuModelMapper();
			var model = new ApiTransactionStatuResponseModel();
			model.SetProperties(1, "A");
			ApiTransactionStatuRequestModel response = mapper.MapResponseToRequest(model);

			response.Name.Should().Be("A");
		}

		[Fact]
		public void CreatePatch()
		{
			var mapper = new ApiTransactionStatuModelMapper();
			var model = new ApiTransactionStatuRequestModel();
			model.SetProperties("A");

			JsonPatchDocument<ApiTransactionStatuRequestModel> patch = mapper.CreatePatch(model);
			var response = new ApiTransactionStatuRequestModel();
			patch.ApplyTo(response);
			response.Name.Should().Be("A");
		}
	}
}

/*<Codenesium>
    <Hash>7b6de7286c551a555aef68474c8e5a8a</Hash>
</Codenesium>*/