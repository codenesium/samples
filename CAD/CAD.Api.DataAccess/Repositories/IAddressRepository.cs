using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public partial interface IAddressRepository
	{
		Task<Address> Create(Address item);

		Task Update(Address item);

		Task Delete(int id);

		Task<Address> Get(int id);

		Task<List<Address>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Call>> CallsByAddressId(int addressId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>691164803bffb6356eeb7b5ce93494ef</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/