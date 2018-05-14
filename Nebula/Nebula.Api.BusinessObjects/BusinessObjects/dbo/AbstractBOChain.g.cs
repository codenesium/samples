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
	public abstract class AbstractBOChain
	{
		private IChainRepository chainRepository;
		private IChainModelValidator chainModelValidator;
		private ILogger logger;

		public AbstractBOChain(
			ILogger logger,
			IChainRepository chainRepository,
			IChainModelValidator chainModelValidator)

		{
			this.chainRepository = chainRepository;
			this.chainModelValidator = chainModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainRepository.All(skip, take, orderClause);
		}

		public virtual POCOChain Get(int id)
		{
			return this.chainRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOChain>> Create(
			ChainModel model)
		{
			CreateResponse<POCOChain> response = new CreateResponse<POCOChain>(await this.chainModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOChain record = this.chainRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ChainModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.chainRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.chainRepository.Delete(id);
			}
			return response;
		}

		public POCOChain ExternalId(Guid externalId)
		{
			return this.chainRepository.ExternalId(externalId);
		}
	}
}

/*<Codenesium>
    <Hash>2bb8212e2d260e2bf0d8124e622b7ed5</Hash>
</Codenesium>*/