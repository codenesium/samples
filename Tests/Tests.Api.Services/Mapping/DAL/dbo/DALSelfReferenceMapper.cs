using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALSelfReferenceMapper : DALAbstractSelfReferenceMapper, IDALSelfReferenceMapper
	{
		public DALSelfReferenceMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>13228a16f90648c38bea6b85eba34592</Hash>
</Codenesium>*/