using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepDestination
	{
		Task<CreateResponse<int>> Create(
			PipelineStepDestinationModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepDestinationModel model);

		Task<ActionResponse> Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStepDestination GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStepDestination> GetWhereDirect(Expression<Func<EFPipelineStepDestination, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d8f53e1c351100020c5b8f155c0ab24c</Hash>
</Codenesium>*/