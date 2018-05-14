using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IChainStatusRepository
	{
		POCOChainStatus Create(ApiChainStatusModel model);

		void Update(int id,
		            ApiChainStatusModel model);

		void Delete(int id);

		POCOChainStatus Get(int id);

		List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOChainStatus Name(string name);
	}
}

/*<Codenesium>
    <Hash>346b7f7fb53f815fa129e372b3577830</Hash>
</Codenesium>*/