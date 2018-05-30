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
	public abstract class AbstractBOPipelineStep: AbstractBOManager
	{
		private IPipelineStepRepository pipelineStepRepository;
		private IApiPipelineStepRequestModelValidator pipelineStepModelValidator;
		private IBOLPipelineStepMapper pipelineStepMapper;
		private ILogger logger;

		public AbstractBOPipelineStep(
			ILogger logger,
			IPipelineStepRepository pipelineStepRepository,
			IApiPipelineStepRequestModelValidator pipelineStepModelValidator,
			IBOLPipelineStepMapper pipelineStepMapper)
			: base()

		{
			this.pipelineStepRepository = pipelineStepRepository;
			this.pipelineStepModelValidator = pipelineStepModelValidator;
			this.pipelineStepMapper = pipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepRepository.All(skip, take, orderClause);

			return this.pipelineStepMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineStepResponseModel> Get(int id)
		{
			var record = await pipelineStepRepository.Get(id);

			return this.pipelineStepMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
			ApiPipelineStepRequestModel model)
		{
			CreateResponse<ApiPipelineStepResponseModel> response = new CreateResponse<ApiPipelineStepResponseModel>(await this.pipelineStepModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineStepMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineStepRepository.Create(dto);

				response.SetRecord(this.pipelineStepMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineStepRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineStepMapper.MapModelToDTO(id, model);
				await this.pipelineStepRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineStepModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineStepRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>da7aeb5ecc7a08c0c57313a48c86a7ab</Hash>
</Codenesium>*/