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
    <Hash>3b5eaf909a779dc616dcf91b87544676</Hash>
</Codenesium>*/