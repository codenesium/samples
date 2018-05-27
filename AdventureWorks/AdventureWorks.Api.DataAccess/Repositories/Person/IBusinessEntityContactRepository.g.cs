using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityContactRepository
	{
		Task<DTOBusinessEntityContact> Create(DTOBusinessEntityContact dto);

		Task Update(int businessEntityID,
		            DTOBusinessEntityContact dto);

		Task Delete(int businessEntityID);

		Task<DTOBusinessEntityContact> Get(int businessEntityID);

		Task<List<DTOBusinessEntityContact>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOBusinessEntityContact>> GetContactTypeID(int contactTypeID);
		Task<List<DTOBusinessEntityContact>> GetPersonID(int personID);
	}
}

/*<Codenesium>
    <Hash>7eb280eb57a80652e44d229891be52d6</Hash>
</Codenesium>*/