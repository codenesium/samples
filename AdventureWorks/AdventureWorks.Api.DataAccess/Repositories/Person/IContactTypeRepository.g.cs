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
	}
}

/*<Codenesium>
    <Hash>d440d20c2b4936cb8b3ab97dde1e3559</Hash>
</Codenesium>*/