using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXStudentRepository
	{
		Task<DTOLessonXStudent> Create(DTOLessonXStudent dto);

		Task Update(int id,
		            DTOLessonXStudent dto);

		Task Delete(int id);

		Task<DTOLessonXStudent> Get(int id);

		Task<List<DTOLessonXStudent>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b779376057e955245dade344efa3b9f4</Hash>
</Codenesium>*/