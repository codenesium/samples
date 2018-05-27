using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		Task<DTOAddressType> Create(DTOAddressType dto);

		Task Update(int addressTypeID,
		            DTOAddressType dto);

		Task Delete(int addressTypeID);

		Task<DTOAddressType> Get(int addressTypeID);

		Task<List<DTOAddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOAddressType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>d42e9cd580829409795e97af9251cbd7</Hash>
</Codenesium>*/