using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int id);

		POCOMachine GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOMachine> GetWhereDirect(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>90f794899ad6c81ece8629faaa96a75e</Hash>
</Codenesium>*/