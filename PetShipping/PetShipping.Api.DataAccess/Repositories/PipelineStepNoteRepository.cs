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
    <Hash>10af01789bf7ffdc6f0cb5ad03e5d30e</Hash>
</Codenesium>*/