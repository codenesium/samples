using System;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		int Create(string description,
		           string jwtKey,
		           string lastIpAddress,
		           Guid machineGuid,
		           string name);

		void Update(int id, string description,
		            string jwtKey,
		            string lastIpAddress,
		            Guid machineGuid,
		            string name);

		void Delete(int id);

		void GetById(int id, Response response);

		void GetWhere(Expression<Func<Machine, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>853e06d999b25111aba9f42e1a2b6c35</Hash>
</Codenesium>*/