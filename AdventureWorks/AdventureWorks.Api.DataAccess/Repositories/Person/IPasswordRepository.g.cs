using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPasswordRepository
	{
		Task<DTOPassword> Create(DTOPassword dto);

		Task Update(int businessEntityID,
		            DTOPassword dto);

		Task Delete(int businessEntityID);

		Task<DTOPassword> Get(int businessEntityID);

		Task<List<DTOPassword>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dd26c87808863f185db018254bbe56e0</Hash>
</Codenesium>*/