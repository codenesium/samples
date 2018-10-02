using Microsoft.EntityFrameworkCore;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial class DALIncludedColumnTestMapper : DALAbstractIncludedColumnTestMapper, IDALIncludedColumnTestMapper
	{
		public DALIncludedColumnTestMapper()
		{
		}
	}
}

/*<Codenesium>
    <Hash>0715fdd72e67cbedd55bb1ce9aabea55</Hash>
</Codenesium>*/