using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityRepository
	{
		Task<BusinessEntity> Create(BusinessEntity item);

		Task Update(BusinessEntity item);

		Task Delete(int businessEntityID);

		Task<BusinessEntity> Get(int businessEntityID);

		Task<List<BusinessEntity>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityAddress>> BusinessEntityAddresses(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<BusinessEntityContact>> BusinessEntityContacts(int businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<List<Person>> People(int businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bdc4cdd52198b62db8a898ea00719eeb</Hash>
</Codenesium>*/