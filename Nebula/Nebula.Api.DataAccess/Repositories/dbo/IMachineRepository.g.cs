using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		int Create(string name,
		           Guid machineGuid,
		           string jwtKey,
		           string lastIpAddress,
		           string description);

		void Update(int id, string name,
		            Guid machineGuid,
		            string jwtKey,
		            string lastIpAddress,
		            string description);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<EFMachine, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5283cf91c7f25db24dd05da3e250dad8</Hash>
</Codenesium>*/