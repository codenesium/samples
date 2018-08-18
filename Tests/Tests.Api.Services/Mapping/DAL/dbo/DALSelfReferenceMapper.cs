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
    <Hash>9003319caf9eb1b397b7c25929a1c0c4</Hash>
</Codenesium>*/