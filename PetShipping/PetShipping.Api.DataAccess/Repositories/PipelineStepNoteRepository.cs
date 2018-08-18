using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial class PipelineStepNoteRepository : AbstractPipelineStepNoteRepository, IPipelineStepNoteRepository
	{
		public PipelineStepNoteRepository(
			ILogger<PipelineStepNoteRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10e1e78ef9cbfba0df297344c28bf841</Hash>
</Codenesium>*/