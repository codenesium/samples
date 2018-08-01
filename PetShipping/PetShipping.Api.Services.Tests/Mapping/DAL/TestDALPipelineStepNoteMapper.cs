using FluentAssertions;
using PetShippingNS.Api.DataAccess;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace PetShippingNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Table", "PipelineStepNote")]
	[Trait("Area", "DALMapper")]
	public class TestDALPipelineStepNoteMapper
	{
		[Fact]
		public void MapBOToEF()
		{
			var mapper = new DALPipelineStepNoteMapper();
			var bo = new BOPipelineStepNote();
			bo.SetProperties(1, 1, "A", 1);

			PipelineStepNote response = mapper.MapBOToEF(bo);

			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBO()
		{
			var mapper = new DALPipelineStepNoteMapper();
			PipelineStepNote entity = new PipelineStepNote();
			entity.SetProperties(1, 1, "A", 1);

			BOPipelineStepNote response = mapper.MapEFToBO(entity);

			response.EmployeeId.Should().Be(1);
			response.Id.Should().Be(1);
			response.Note.Should().Be("A");
			response.PipelineStepId.Should().Be(1);
		}

		[Fact]
		public void MapEFToBOList()
		{
			var mapper = new DALPipelineStepNoteMapper();
			PipelineStepNote entity = new PipelineStepNote();
			entity.SetProperties(1, 1, "A", 1);

			List<BOPipelineStepNote> response = mapper.MapEFToBO(new List<PipelineStepNote>() { entity });

			response.Count.Should().Be(1);
		}
	}
}

/*<Codenesium>
    <Hash>64325223896dd1f60fcc5d506141fd95</Hash>
</Codenesium>*/