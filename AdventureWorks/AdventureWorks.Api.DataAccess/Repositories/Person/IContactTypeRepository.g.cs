using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IContactTypeRepository
	{
		Task<ContactType> Create(ContactType item);

		Task Update(ContactType item);

		Task Delete(int contactTypeID);

		Task<ContactType> Get(int contactTypeID);

		Task<List<ContactType>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<ContactType> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>3e71ec22ac1c0843e8e27406c69b7f7f</Hash>
</Codenesium>*/