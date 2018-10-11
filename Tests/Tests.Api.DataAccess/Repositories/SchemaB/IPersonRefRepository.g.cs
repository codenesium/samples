using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public partial interface IPersonRefRepository
	{
		Task<PersonRef> Create(PersonRef item);

		Task Update(PersonRef item);

		Task Delete(int id);

		Task<PersonRef> Get(int id);

		Task<List<PersonRef>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>4e66d72bc0ba479078e3998dcae0d4e1</Hash>
</Codenesium>*/