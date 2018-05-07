using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public abstract class AbstractBOPipelineStatus
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IPipelineStatusModelValidator pipelineStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStatus(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IPipelineStatusModelValidator pipelineStatusModelValidator)

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PipelineStatusModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.pipelineStatusRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			PipelineStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.pipelineStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOPipelineStatus Get(int id)
		{
			return this.pipelineStatusRepository.Get(id);
		}

		public virtual List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4880d2e05af71d164db636b309aef76e</Hash>
</Codenesium>*/