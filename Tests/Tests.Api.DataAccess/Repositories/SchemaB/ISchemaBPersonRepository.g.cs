using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
	public interface ISchemaBPersonRepository
	{
		Task<SchemaBPerson> Create(SchemaBPerson item);

		Task Update(SchemaBPerson item);

		Task Delete(int id);

		Task<SchemaBPerson> Get(int id);

		Task<List<SchemaBPerson>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PersonRef>> PersonRefs(int personBId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6b54102dc25c1e0c61d2bde349c8797d</Hash>
</Codenesium>*/