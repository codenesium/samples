using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		int Create(PipelineStatusModel model);

		void Update(int id,
		            PipelineStatusModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOPipelineStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOPipelineStatus> GetWhereDirect(Expression<Func<EFPipelineStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9a1c6204bad329fdc0bce1b1b4cbf9ce</Hash>
</Codenesium>*/