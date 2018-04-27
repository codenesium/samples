using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		int Create(PipelineStepStatusModel model);

		void Update(int id,
		            PipelineStepStatusModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepStatus> GetWhereDirect(Expression<Func<EFPipelineStepStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>69b0a34510677c7101e22b7b95a7f400</Hash>
</Codenesium>*/