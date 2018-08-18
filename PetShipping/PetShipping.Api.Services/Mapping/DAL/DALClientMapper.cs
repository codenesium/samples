using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALClientMapper : DALAbstractClientMapper, IDALClientMapper
	{
		public DALClientMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>a9366b04e36b2527e7ab435a65d28fa6</Hash>
</Codenesium>*/