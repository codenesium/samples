using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonXTeacherRepository
	{
		Task<DTOLessonXTeacher> Create(DTOLessonXTeacher dto);

		Task Update(int id,
		            DTOLessonXTeacher dto);

		Task Delete(int id);

		Task<DTOLessonXTeacher> Get(int id);

		Task<List<DTOLessonXTeacher>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c9b1e3fe8a779a86d131b4f33b94cfec</Hash>
</Codenesium>*/