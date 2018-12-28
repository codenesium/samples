using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class PipelineStepNoteService : AbstractPipelineStepNoteService, IPipelineStepNoteService
	{
		public PipelineStepNoteService(
			ILogger<IPipelineStepNoteRepository> logger,
			IMediator mediator,
			IPipelineStepNoteRepository pipelineStepNoteRepository,
			IApiPipelineStepNoteServerRequestModelValidator pipelineStepNoteModelValidator,
			IBOLPipelineStepNoteMapper bolPipelineStepNoteMapper,
			IDALPipelineStepNoteMapper dalPipelineStepNoteMapper)
			: base(logger,
			       mediator,
			       pipelineStepNoteRepository,
			       pipelineStepNoteModelValidator,
			       bolPipelineStepNoteMapper,
			       dalPipelineStepNoteMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a34f0d23d17c0f4d25b57c1ebd4f4bc9</Hash>
</Codenesium>*/