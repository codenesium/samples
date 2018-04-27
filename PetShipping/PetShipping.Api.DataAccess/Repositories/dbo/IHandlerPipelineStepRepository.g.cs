using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		int Create(HandlerPipelineStepModel model);

		void Update(int id,
		            HandlerPipelineStepModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOHandlerPipelineStep GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOHandlerPipelineStep> GetWhereDirect(Expression<Func<EFHandlerPipelineStep, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>95e9e83f1ee8a268a63c777857d5552e</Hash>
</Codenesium>*/