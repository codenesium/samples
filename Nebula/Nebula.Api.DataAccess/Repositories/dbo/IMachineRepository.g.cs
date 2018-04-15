using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IMachineRepository
	{
		int Create(MachineModel model);

		void Update(int id,
		            MachineModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOMachine GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOMachine> GetWhereDirect(Expression<Func<EFMachine, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1510c1dc21721eb69205acd6eca18cbd</Hash>
</Codenesium>*/