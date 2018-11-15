using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
	{
		public PipelineStepNoteService(
			ILogger<IPipelineStepNoteRepository> logger,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteServerRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base(logger,
			       pipelineStepNoteRepository,
			       pipelineStepNoteModelValidator,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>8938da994e0db4ccd258aff033339805</Hash>
</Codenesium>*/