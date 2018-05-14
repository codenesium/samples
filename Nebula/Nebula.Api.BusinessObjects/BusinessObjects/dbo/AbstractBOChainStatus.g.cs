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

		public virtual List<POCOChainStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.chainStatusRepository.All(skip, take, orderClause);
		}

		public virtual POCOChainStatus Get(int id)
		{
			return this.chainStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOChainStatus>> Create(
			ChainStatusModel model)
		{
			CreateResponse<POCOChainStatus> response = new CreateResponse<POCOChainStatus>(await this.chainStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOChainStatus record = this.chainStatusRepository.Create(model);
				response.SetRecord(record);
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

		public POCOChainStatus Name(string name)
		{
			return this.chainStatusRepository.Name(name);
		}
	}
}

/*<Codenesium>
    <Hash>520907220af809d032510beb42defa3d</Hash>
</Codenesium>*/