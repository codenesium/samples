using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class DALPaymentTypeMapper : DALAbstractPaymentTypeMapper, IDALPaymentTypeMapper
	{
		public DALPaymentTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3d9aab2a54bc455e894657e96b8dd0ef</Hash>
</Codenesium>*/