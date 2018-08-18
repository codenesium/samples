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
    <Hash>2e3b9e36da134fcf0b0b18476df55db2</Hash>
</Codenesium>*/