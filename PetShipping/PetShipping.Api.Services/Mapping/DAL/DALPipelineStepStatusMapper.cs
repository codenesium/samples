using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALPipelineStepStatusMapper : DALAbstractPipelineStepStatusMapper, IDALPipelineStepStatusMapper
	{
		public DALPipelineStepStatusMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>fa52f9ba256f1f839b57b68bf84f88cb</Hash>
</Codenesium>*/