using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ILessonRepository
	{
		int Create(
			Nullable<DateTime> scheduledStartDate,
			Nullable<DateTime> scheduledEndDate,
			Nullable<DateTime> actualStartDate,
			Nullable<DateTime> actualEndDate,
			int lessonStatusId,
			string teacherNotes,
			string studentNotes,
			Nullable<decimal> billAmount,
			int studioId);

		void Update(int id,
		            Nullable<DateTime> scheduledStartDate,
		            Nullable<DateTime> scheduledEndDate,
		            Nullable<DateTime> actualStartDate,
		            Nullable<DateTime> actualEndDate,
		            int lessonStatusId,
		            string teacherNotes,
		            string studentNotes,
		            Nullable<decimal> billAmount,
		            int studioId);

		void Delete(int id);

		Response GetById(int id);

		POCOLesson GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLesson> GetWhereDirect(Expression<Func<EFLesson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>43818a8fd1f0e065903322475a75cc78</Hash>
</Codenesium>*/