using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IBusinessEntityRepository
	{
		Task<BusinessEntity> Create(BusinessEntity item);

		Task Update(BusinessEntity item);

		Task Delete(int businessEntityID);

		Task<BusinessEntity> Get(int businessEntityID);

		Task<List<BusinessEntity>> All(int limit = int.MaxValue, int offset = 0);

		Task<BusinessEntity> ByRowguid(Guid rowguid);

		Task<List<Person>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>542a9332ddad0663b11ffd12414dc5c9</Hash>
</Codenesium>*/