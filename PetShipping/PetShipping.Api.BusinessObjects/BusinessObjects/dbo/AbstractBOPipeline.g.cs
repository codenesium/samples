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
	public abstract class AbstractBOPipeline: AbstractBOManager
	{
		private IPipelineRepository pipelineRepository;
		private IApiPipelineRequestModelValidator pipelineModelValidator;
		private IBOLPipelineMapper pipelineMapper;
		private ILogger logger;

		public AbstractBOPipeline(
			ILogger logger,
			IPipelineRepository pipelineRepository,
			IApiPipelineRequestModelValidator pipelineModelValidator,
			IBOLPipelineMapper pipelineMapper)
			: base()

		{
			this.pipelineRepository = pipelineRepository;
			this.pipelineModelValidator = pipelineModelValidator;
			this.pipelineMapper = pipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineRepository.All(skip, take, orderClause);

			return this.pipelineMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPipelineResponseModel> Get(int id)
		{
			var record = await pipelineRepository.Get(id);

			return this.pipelineMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPipelineResponseModel>> Create(
			ApiPipelineRequestModel model)
		{
			CreateResponse<ApiPipelineResponseModel> response = new CreateResponse<ApiPipelineResponseModel>(await this.pipelineModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.pipelineMapper.MapModelToDTO(default (int), model);
				var record = await this.pipelineRepository.Create(dto);

				response.SetRecord(this.pipelineMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiPipelineRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.pipelineMapper.MapModelToDTO(id, model);
				await this.pipelineRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.pipelineModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.pipelineRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>bd3133996eba29cd0c9b9f0aa81b4c93</Hash>
</Codenesium>*/