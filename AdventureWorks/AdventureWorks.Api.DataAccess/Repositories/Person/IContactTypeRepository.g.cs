using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		Task<DTOContactType> Create(DTOContactType dto);

		Task Update(int contactTypeID,
		            DTOContactType dto);

		Task Delete(int contactTypeID);

		Task<DTOContactType> Get(int contactTypeID);

		Task<List<DTOContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOContactType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>4509bfb18b0852b86e9e0bacda0959e9</Hash>
</Codenesium>*/