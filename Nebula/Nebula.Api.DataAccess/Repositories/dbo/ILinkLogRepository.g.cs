using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		int Create(int linkId,
		           string log,
		           DateTime dateEntered);

		void Update(int id, int linkId,
		            string log,
		            DateTime dateEntered);

		void Delete(int id);

		Response GetById(int id);

		POCOLinkLog GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOLinkLog> GetWhereDirect(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>197c5a15a485e630bdac788c83766c8e</Hash>
</Codenesium>*/