using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IBusinessEntityAddressRepository
	{
		Task<DTOBusinessEntityAddress> Create(DTOBusinessEntityAddress dto);

		Task Update(int businessEntityID,
		            DTOBusinessEntityAddress dto);

		Task Delete(int businessEntityID);

		Task<DTOBusinessEntityAddress> Get(int businessEntityID);

		Task<List<DTOBusinessEntityAddress>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOBusinessEntityAddress>> GetAddressID(int addressID);
		Task<List<DTOBusinessEntityAddress>> GetAddressTypeID(int addressTypeID);
	}
}

/*<Codenesium>
    <Hash>8f9aec5b1f6a550e3f61e0060e8df6f1</Hash>
</Codenesium>*/