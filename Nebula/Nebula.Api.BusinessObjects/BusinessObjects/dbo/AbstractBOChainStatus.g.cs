using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOChainStatus
	{
		private IChainStatusRepository chainStatusRepository;
		private IChainStatusModelValidator chainStatusModelValidator;
		private ILogger logger;

		public AbstractBOChainStatus(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IChainStatusModelValidator chainStatusModelValidator)

		{
			this.chainStatusRepository = chainStatusRepository;
			this.chainStatusModelValidator = chainStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ChainStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.chainStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ChainStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.chainStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.chainStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual ApiResponse GetById(int id)
		{
			return this.chainStatusRepository.GetById(id);
		}

		public virtual POCOChainStatus GetByIdDirect(int id)
		{
			return this.chainStatusRepository.GetByIdDirect(id);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainStatusRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainStatusRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOChainStatus> GetWhereDirect(Expression<Func<EFChainStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainStatusRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c11f8edebe3b498a1bbff66758d8ee04</Hash>
</Codenesium>*/