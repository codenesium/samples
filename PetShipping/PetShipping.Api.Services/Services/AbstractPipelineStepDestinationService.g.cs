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

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepDestinationService: AbstractService
	{
		private IPipelineStepDestinationRepository pipelineStepDestinationRepository;
		private IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator;
		private IBOLPipelineStepDestinationMapper BOLPipelineStepDestinationMapper;
		private IDALPipelineStepDestinationMapper DALPipelineStepDestinationMapper;
		private ILogger logger;

		public AbstractPipelineStepDestinationService(
			ILogger logger,
			IPipelineStepDestinationRepository pipelineStepDestinationRepository,
			IApiPipelineStepDestinationRequestModelValidator pipelineStepDestinationModelValidator,
			IBOLPipelineStepDestinationMapper bolpipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalpipelineStepDestinationMapper)
			: base()

		{
			this.pipelineStepDestinationRepository = pipelineStepDestinationRepository;
			this.pipelineStepDestinationModelValidator = pipelineStepDestinationModelValidator;
			this.BOLPipelineStepDestinationMapper = bolpipelineStepDestinationMapper;
			this.DALPipelineStepDestinationMapper = dalpipelineStepDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepDestinationRepository.All(skip, take, orderClause);

			return this.BOLPipelineStepDestinationMapper.MapBOToModel(this.DALPipelineStepDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> Get(int id)
		{
			var record = await pipelineStepDestinationRepository.Get(id);

			return this.BOLPipelineStepDestinationMapper.MapBOToModel(this.DALPipelineStepDestinationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
			ApiPipelineStepDestinationRequestModel model)
		{
			CreateResponse<ApiPipelineStepDestinationResponseModel> response = new CreateResponse<ApiPipelineStepDestinationResponseModel>(await this.pipelineStepDestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPipelineStepDestinationMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineStepDestinationRepository.Create(this.DALPipelineStepDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPipelineStepDestinationMapper.MapBOToModel(this.DALPipelineStepDestinationMapper.MapEFToBO(record)));
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
				var bo = this.BOLPipelineStepDestinationMapper.MapModelToBO(id, model);
				await this.pipelineStepDestinationRepository.Update(this.DALPipelineStepDestinationMapper.MapBOToEF(bo));
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
    <Hash>9633e56b2c7e5e9c1d5bb851f9c0a234</Hash>
</Codenesium>*/