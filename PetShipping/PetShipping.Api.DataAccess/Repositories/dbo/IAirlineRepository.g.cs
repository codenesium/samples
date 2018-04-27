using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirlineRepository
	{
		int Create(AirlineModel model);

		void Update(int id,
		            AirlineModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOAirline GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAirline> GetWhereDirect(Expression<Func<EFAirline, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>270380c605a7e92dda05954948175a53</Hash>
</Codenesium>*/