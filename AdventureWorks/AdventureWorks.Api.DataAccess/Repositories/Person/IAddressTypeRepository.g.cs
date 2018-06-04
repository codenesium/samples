using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAddressTypeRepository
	{
		Task<AddressType> Create(AddressType item);

		Task Update(AddressType item);

		Task Delete(int addressTypeID);

		Task<AddressType> Get(int addressTypeID);

		Task<List<AddressType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<AddressType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>51c2bb79e2c1192c05a74ea10b54ec3d</Hash>
</Codenesium>*/