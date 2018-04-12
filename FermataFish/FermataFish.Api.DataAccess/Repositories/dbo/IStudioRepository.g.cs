using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface IStudioRepository
	{
		int Create(
			string name,
			string website,
			string address1,
			string address2,
			string city,
			int stateId,
			string zip);

		void Update(int id,
		            string name,
		            string website,
		            string address1,
		            string address2,
		            string city,
		            int stateId,
		            string zip);

		void Delete(int id);

		Response GetById(int id);

		POCOStudio GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOStudio> GetWhereDirect(Expression<Func<EFStudio, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f5921a575ffba77005d440a32c08f86c</Hash>
</Codenesium>*/