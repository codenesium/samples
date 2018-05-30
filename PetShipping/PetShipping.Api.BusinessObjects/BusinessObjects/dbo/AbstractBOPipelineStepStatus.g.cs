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
	public abstract class AbstractBOPipelineStepStatus: AbstractBOManager
	{
		private IPipelineStepStatusRepository pipelineStepStatusRepository;
		private IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator;
		private IBOLPipelineStepStatusMapper pipelineStepStatusMapper;
		private ILogger logger;

		public AbstractBOPipelineStepStatus(
			ILogger logger,
			IPipelineStepStatusRepository pipelineStepStatusRepository,
			IApiPipelineStepStatusRequestModelValidator pipelineStepStatusModelValidator,
			IBOLPipelineStepStatusMapper pipelineStepStatusMapper)
			: base()

		{
			this.pipelineStepStatusRepository = pipelineStepStatusRepository;
			this.pipelineStepStatusModelValidator = pipelineStepStatusModelValidator;
			this.pipelineStepStatusMapper = pipelineStepStatusMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStatusResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepStatusRepository.All(skip, take, orderClause);

			return this.pipelineStepStatusMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStepStatusResponseModel> Get(int id)
		{
			var record = await pipelineStepStatusRepository.Get(id);

			return this.pipelineStepStatusMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
			ApiPipelineStepStatusRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatusResponseModel> response = new CreateResponse<ApiPipelineStepStatusResponseModel>(await this.pipelineStepStatusModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStepStatusMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStepStatusRepository.Create(dto);

				response.SetRecord(this.pipelineStepStatusMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepStatusRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStepStatusMapper.MapModelToDTO(id, model);
				await this.pipelineStepStatusRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepStatusModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepStatusRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d3f0aecda788001247317ff5cd9968ee</Hash>
</Codenesium>*/