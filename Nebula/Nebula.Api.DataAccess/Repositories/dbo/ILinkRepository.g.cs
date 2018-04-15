using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkRepository
	{
		int Create(LinkModel model);

		void Update(int id,
		            LinkModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLink GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLink> GetWhereDirect(Expression<Func<EFLink, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>43a497c637996d4978833ea8d159daae</Hash>
</Codenesium>*/