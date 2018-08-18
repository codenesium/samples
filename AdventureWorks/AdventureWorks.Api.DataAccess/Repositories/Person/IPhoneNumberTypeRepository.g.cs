using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IPhoneNumberTypeRepository
	{
		Task<PhoneNumberType> Create(PhoneNumberType item);

		Task Update(PhoneNumberType item);

		Task Delete(int phoneNumberTypeID);

		Task<PhoneNumberType> Get(int phoneNumberTypeID);

		Task<List<PhoneNumberType>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PersonPhone>> PersonPhones(int phoneNumberTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c100c20715e31bff2460c22d90d32943</Hash>
</Codenesium>*/