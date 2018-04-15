using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IPersonPhoneRepository
	{
		int Create(PersonPhoneModel model);

		void Update(int businessEntityID,
		            PersonPhoneModel model);

		void Delete(int businessEntityID);

		ApiResponse GetById(int businessEntityID);

		POCOPersonPhone GetByIdDirect(int businessEntityID);

		ApiResponse GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPersonPhone> GetWhereDirect(Expression<Func<EFPersonPhone, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>caac9e50fdf40027aec3f38113a6d378</Hash>
</Codenesium>*/