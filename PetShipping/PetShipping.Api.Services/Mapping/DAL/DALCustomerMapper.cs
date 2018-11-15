using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
	{
		public DALCustomerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>3225ab149d9e0499d0f13bb4a4309cf2</Hash>
</Codenesium>*/