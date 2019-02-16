using FluentAssertions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepNoteMapper
	{
		[Fact]
		public void MapModelToEntity()
		{
			var mapper = new DALPipelineStepNoteMapper();
			ApiPipelineStepNoteServerRequestModel model = new ApiPipelineStepNoteServerRequestModel();
			model.SetProperties(1, "A", 1);
			PipelineStepNote response = mapper.MapModelToEntity(1, model);

			response.EmployeeId.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModel()
		{
			var mapper = new DALPipelineStepNoteMapper();
			PipelineStepNote item = new PipelineStepNote();
			item.SetProperties(1, 1, "A", 1);
			ApiPipelineStepNoteServerResponseModel response = mapper.MapEntityToModel(item);

			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEntityToModelList()
		{
			var mapper = new DALPipelineStepNoteMapper();
			PipelineStepNote item = new PipelineStepNote();
			item.SetProperties(1, 1, "A", 1);
			List<ApiPipelineStepNoteServerResponseModel> response = mapper.MapEntityToModel(new List<PipelineStepNote>() { { item} });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>572e8e8d2189ea95dfbb2e736b9858ac</Hash>
</Codenesium>*/