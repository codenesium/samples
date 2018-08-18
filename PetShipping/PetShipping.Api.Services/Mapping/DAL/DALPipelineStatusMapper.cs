using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALPipelineStatusMapper : DALAbstractPipelineStatusMapper, IDALPipelineStatusMapper
	{
		public DALPipelineStatusMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c771c412bca2a01a33127ae87de052cc</Hash>
</Codenesium>*/