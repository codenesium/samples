using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepRepository
	{
		int Create(PipelineStepModel model);

		void Update(int id,
		            PipelineStepModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStep GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStep> GetWhereDirect(Expression<Func<EFPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b0a2b4b8e8389b2fa36d359608c9346b</Hash>
</Codenesium>*/