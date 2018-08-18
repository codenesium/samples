using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public partial class DALEmployeeMapper : DALAbstractEmployeeMapper, IDALEmployeeMapper
	{
		public DALEmployeeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>9f4db7c4bb48148ea7acfe2920020d17</Hash>
</Codenesium>*/