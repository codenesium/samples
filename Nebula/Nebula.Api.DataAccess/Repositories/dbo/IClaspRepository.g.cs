using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IClaspRepository
	{
		int Create(int previousChainId,
		           int nextChainId);

		void Update(int id, int previousChainId,
		            int nextChainId);

		void Delete(int id);

		Response GetById(int id);

		POCOClasp GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOClasp> GetWhereDirect(Expression<Func<EFClasp, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f3eb2a116aa10c36e63862f979820511</Hash>
</Codenesium>*/