using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudentXFamilyRepository
	{
		Task<DTOStudentXFamily> Create(DTOStudentXFamily dto);

		Task Update(int id,
		            DTOStudentXFamily dto);

		Task Delete(int id);

		Task<DTOStudentXFamily> Get(int id);

		Task<List<DTOStudentXFamily>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>28a5ed1b9bbf24caafadbadce2f1009f</Hash>
</Codenesium>*/