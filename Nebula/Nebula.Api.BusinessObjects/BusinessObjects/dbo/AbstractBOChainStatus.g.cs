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
	public abstract class AbstractBOChainStatus: AbstractBOManager
	{
		private IChainStatusRepository chainStatusRepository;
		private IApiChainStatusModelValidator chainStatusModelValidator;
		private ILogger logger;

		public AbstractBOChainStatus(
			ILogger logger,
			IChainStatusRepository chainStatusRepository,
			IApiChainStatusModelValidator chainStatusModelValidator)
			: base()

		{
			this.chainStatusRepository = chainStatusRepository;
			this.chainStatusModelValidator = chainStatusModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOChainStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainStatusRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOChainStatus> Get(int id)
		{
			return this.chainStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOChainStatus>> Create(
			ApiChainStatusModel model)
		{
			CreateResponse<POCOChainStatus> response = new CreateResponse<POCOChainStatus>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOChainStatus record = await this.chainStatusRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiChainStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.chainStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.chainStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.chainStatusRepository.Delete(id);
			}
			return response;
		}

		public async Task<POCOChainStatus> Name(string name)
		{
			return await this.chainStatusRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>e28406f1a9b4d64ca52522bb9e4a5c6b</Hash>
</Codenesium>*/