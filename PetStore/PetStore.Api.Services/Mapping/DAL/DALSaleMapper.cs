using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public partial class DALSaleMapper : DALAbstractSaleMapper, IDALSaleMapper
	{
		public DALSaleMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c40e50b194f0cad72c34b5b044c88ec8</Hash>
</Codenesium>*/