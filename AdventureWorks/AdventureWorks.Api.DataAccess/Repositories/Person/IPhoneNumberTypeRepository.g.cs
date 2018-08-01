using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPhoneNumberTypeRepository
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
    <Hash>59db55c0c2d07268a457a64478342e3d</Hash>
</Codenesium>*/