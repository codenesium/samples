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
    <Hash>73bde7fa97433fbe4905cd2e0631e31e</Hash>
</Codenesium>*/