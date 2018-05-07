using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOLessonXStudent
	{
		Task<CreateResponse<int>> Create(
			LessonXStudentModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXStudentModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonXStudent Get(int id);

		List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a06ebd2bbaa247a2102cc9ec76c91677</Hash>
</Codenesium>*/