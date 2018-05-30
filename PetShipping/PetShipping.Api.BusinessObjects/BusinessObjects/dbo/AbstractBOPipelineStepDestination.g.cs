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
	public abstract class AbstractBOPipelineStepDestination: AbstractBOManager
	{
		private IPipelineStepDestinationRepository pipelineStepDestinationRepository;
		private IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator;
		private IBOLPipelineStepDestinationMapper pipelineStepDestinationMapper;
		private ILogger logger;

		public AbstractBOPipelineStepDestination(
			ILogger logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper pipelineStepDestinationMapper)
			: base()

		{
			this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.pipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.pipelineStepDestinationMapper = pipelineStepDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepDestinationRepository.All(skip, take, orderClause);

			return this.pipelineStepDestinationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> Get(int id)
		{
			var record = await pipelineStepDestinationRepository.Get(id);

			return this.pipelineStepDestinationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
			ApiPipelineStepDestinationRequestModel model)
		{
			CreateResponse<ApiPipelineStepDestinationResponseModel> response = new CreateResponse<ApiPipelineStepDestinationResponseModel>(await this.pipelineStepDestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStepDestinationMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStepDestinationRepository.Create(dto);

				response.SetRecord(this.pipelineStepDestinationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepDestinationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepDestinationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStepDestinationMapper.MapModelToDTO(id, model);
				await this.pipelineStepDestinationRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepDestinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepDestinationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>e1f41b45c5703e7ed2c37a48ea4fba9f</Hash>
</Codenesium>*/