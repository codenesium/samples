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

		Task<List<BusinessEntityAddress>> BusinessEntityAddressesByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityContact>> BusinessEntityContactsByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> PeopleByBusinessEntityID(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>9e8478a4e0755e8cffbe13b4c075b423</Hash>
</Codenesium>*/