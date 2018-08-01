using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
	{
		public DALCustomerMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>c6c8ef02be08a61cda5702ad1bac15e4</Hash>
</Codenesium>*/