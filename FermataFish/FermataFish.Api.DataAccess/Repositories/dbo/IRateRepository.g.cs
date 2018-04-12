using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IRateRepository
	{
		int Create(
			decimal amountPerMinute,
			int teacherSkillId,
			int teacherId);

		void Update(int id,
		            decimal amountPerMinute,
		            int teacherSkillId,
		            int teacherId);

		void Delete(int id);

		Response GetById(int id);

		POCORate GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCORate> GetWhereDirect(Expression<Func<EFRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0fd3cecf0df6e1ad0098b3e7a5c39e08</Hash>
</Codenesium>*/