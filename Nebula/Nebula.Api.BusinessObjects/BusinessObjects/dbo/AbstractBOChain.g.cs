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

		public virtual async Task<CreateResponse<int>> Create(
			ChainModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.chainModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.chainRepository.Create(model);
				response.SetId(id);
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

		public virtual POCOChain Get(int id)
		{
			return this.chainRepository.Get(id);
		}

		public virtual List<POCOChain> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>69e0e33fff5691c6214d834170314c07</Hash>
</Codenesium>*/