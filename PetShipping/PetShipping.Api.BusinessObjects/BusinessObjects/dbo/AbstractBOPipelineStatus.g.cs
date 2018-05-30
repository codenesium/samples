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
		private IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator;
		private IBOLPipelineStatusMapper pipelineStatusMapper;
		private ILogger logger;

		public AbstractBOPipelineStatus(
			ILogger logger,
			IPipelineStatusRepository pipelineStatusRepository,
			IApiPipelineStatusRequestModelValidator pipelineStatusModelValidator,
			IBOLPipelineStatusMapper pipelineStatusMapper)
			: base()

		{
			this.pipelineStatusRepository = pipelineStatusRepository;
			this.pipelineStatusModelValidator = pipelineStatusModelValidator;
			this.pipelineStatusMapper = pipelineStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStatusRepository.All(skip, take, orderClause);

			return this.pipelineStatusMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStatusResponseModel> Get(int id)
		{
			var record = await pipelineStatusRepository.Get(id);

			return this.pipelineStatusMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
			ApiPipelineStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStatusResponseModel> response = new CreateResponse<ApiPipelineStatusResponseModel>(await this.pipelineStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStatusMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStatusRepository.Create(dto);

				response.SetRecord(this.pipelineStatusMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStatusMapper.MapModelToDTO(id, model);
				await this.pipelineStatusRepository.Update(id, dto);
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
    <Hash>1bd34241e6364a6f8e58beb75548c30a</Hash>
</Codenesium>*/