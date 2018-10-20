using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IContactTypeRepository
	{
		Task<ContactType> Create(ContactType item);

		Task Update(ContactType item);

		Task Delete(int contactTypeID);

		Task<ContactType> Get(int contactTypeID);

		Task<List<ContactType>> All(int limit = int.MaxValue, int offset = 0);

		Task<ContactType> ByName(string name);

		Task<List<BusinessEntityContact>> BusinessEntityContactsByContactTypeID(int contactTypeID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b95b07cfcdea50de3f38e911de7c3f40</Hash>
</Codenesium>*/