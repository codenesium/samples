using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBODepartment
	{
		Task<CreateResponse<short>> Create(
			DepartmentModel model);

		Task<ActionResponse> Update(short departmentID,
		                            DepartmentModel model);

		Task<ActionResponse> Delete(short departmentID);

		ApiResponse GetById(short departmentID);

		POCODepartment GetByIdDirect(short departmentID);

		ApiResponse GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f6eb2cbdff108c7b9c650adc2cfadb6e</Hash>
</Codenesium>*/