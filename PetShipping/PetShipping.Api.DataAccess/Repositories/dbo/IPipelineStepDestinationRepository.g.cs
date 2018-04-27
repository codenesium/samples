using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		int Create(PipelineStepDestinationModel model);

		void Update(int id,
		            PipelineStepDestinationModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepDestination GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepDestination> GetWhereDirect(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b62964c344fc6ca8f801f050f1ba8fbb</Hash>
</Codenesium>*/