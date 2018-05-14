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
		Task<CreateResponse<POCOLessonXStudent>> Create(
			LessonXStudentModel model);

		Task<ActionResponse> Update(int id,
		                            LessonXStudentModel model);

		Task<ActionResponse> Delete(int id);

		POCOLessonXStudent Get(int id);

		List<POCOLessonXStudent> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6183447df8fe48a9ed29fe38c1fd11c8</Hash>
</Codenesium>*/