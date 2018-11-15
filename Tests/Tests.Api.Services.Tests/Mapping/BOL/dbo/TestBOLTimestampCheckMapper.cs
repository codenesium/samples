using FluentAssertions;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;
using TestsNS.Api.Services;
using Xunit;

namespace TestsNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "TimestampCheck")]
	[Trait("Area", "BOLMapper")]
	public class TestBOLTimestampCheckMapper
	{
		[Fact]
		public void MapModelToBO()
		{
			var mapper = new BOLTimestampCheckMapper();
			ApiTimestampCheckServerRequestModel model = new ApiTimestampCheckServerRequestModel();
			model.SetProperties("A", BitConverter.GetBytes(1));
			BOTimestampCheck response = mapper.MapModelToBO(1, model);

			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapBOToModel()
		{
			var mapper = new BOLTimestampCheckMapper();
			BOTimestampCheck bo = new BOTimestampCheck();
			bo.SetProperties(1, "A", BitConverter.GetBytes(1));
			ApiTimestampCheckServerResponseModel response = mapper.MapBOToModel(bo);

			response.Id.Should().Be(1);
			response.Name.Should().Be("A");
			response.Timestamp.Should().BeEquivalentTo(BitConverter.GetBytes(1));
		}

		[Fact]
		public void MapBOToModelList()
		{
			var mapper = new BOLTimestampCheckMapper();
			BOTimestampCheck bo = new BOTimestampCheck();
			bo.SetProperties(1, "A", BitConverter.GetBytes(1));
			List<ApiTimestampCheckServerResponseModel> response = mapper.MapBOToModel(new List<BOTimestampCheck>() { { bo } });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>ef0580ce43b89be0c0df8269e4c393df</Hash>
</Codenesium>*/