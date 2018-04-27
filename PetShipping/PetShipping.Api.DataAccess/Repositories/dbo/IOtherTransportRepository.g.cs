using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		int Create(OtherTransportModel model);

		void Update(int id,
		            OtherTransportModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOOtherTransport GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFOtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOOtherTransport> GetWhereDirect(Expression<Func<EFOtherTransport, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>da5ef38efda8e0bcd3b6917d9c1ec42a</Hash>
</Codenesium>*/