using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
	{
		Task<DTOPhoneNumberType> Create(DTOPhoneNumberType dto);

		Task Update(int phoneNumberTypeID,
		            DTOPhoneNumberType dto);

		Task Delete(int phoneNumberTypeID);

		Task<DTOPhoneNumberType> Get(int phoneNumberTypeID);

		Task<List<DTOPhoneNumberType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>484f7d82e5fb0728db4b1530a7b201b3</Hash>
</Codenesium>*/