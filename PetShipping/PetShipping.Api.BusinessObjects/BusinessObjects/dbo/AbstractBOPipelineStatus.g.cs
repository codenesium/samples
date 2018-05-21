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
	public abstract class AbstractBOPipelineStatus: AbstractBOManager
	{
		private IPipelineStatusRepository pipelineStatusRepository;
		private IApiPipelineStatusModelValidator pipelineStatusModelValidator;
		private ILogger logger;

		public AbstractBOPipelineStatus(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusModelValidator pipelineStatusModelValidator)
			: base()

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOPipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.pipelineStatusRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOPipelineStatus> Get(int id)
		{
			return this.pipelineStatusRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOPipelineStatus>> Create(
			ApiPipelineStatusModel model)
		{
			CreateResponse<POCOPipelineStatus> response = new CreateResponse<POCOPipelineStatus>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOPipelineStatus record = await this.pipelineStatusRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStatusModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.pipelineStatusRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>6254eca0f0353df1c4c91239365ea71b</Hash>
</Codenesium>*/