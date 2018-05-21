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
	public abstract class AbstractBOChain: AbstractBOManager
	{
		private IChainRepository chainRepository;
		private IApiChainModelValidator chainModelValidator;
		private ILogger logger;

		public AbstractBOChain(
			ILogger logger,
			IChainRepository chainRepository,
			IApiChainModelValidator chainModelValidator)
			: base()

		{
			this.chainRepository = chainRepository;
			this.chainModelValidator = chainModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOChain>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOChain> Get(int id)
		{
			return this.chainRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOChain>> Create(
			ApiChainModel model)
		{
			CreateResponse<POCOChain> response = new CreateResponse<POCOChain>(await this.chainModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOChain record = await this.chainRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiChainModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.chainRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.chainRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCOChain> ExternalId(Guid externalId)
		{
			return await this.chainRepository.ExternalId(externalId);
		}
	}
}

/*<Codenesium>
    <Hash>c689f26ed702e89c7029dfd063bf2647</Hash>
</Codenesium>*/