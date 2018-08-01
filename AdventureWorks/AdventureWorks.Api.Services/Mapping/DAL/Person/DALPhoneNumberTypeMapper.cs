using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
	public partial class DALPhoneNumberTypeMapper : DALAbstractPhoneNumberTypeMapper, IDALPhoneNumberTypeMapper
	{
		public DALPhoneNumberTypeMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>092b07edaa5f7af9e0396d7e18edf40f</Hash>
</Codenesium>*/