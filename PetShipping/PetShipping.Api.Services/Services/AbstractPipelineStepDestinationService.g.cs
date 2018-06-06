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
		private IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper;
		private IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper;
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
			this.bolPipelineStepDestinationMapper = bolpipelineStepDestinationMapper;
			this.dalPipelineStepDestinationMapper = dalpipelineStepDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.pipelineStepDestinationRepository.All(skip, take, orderClause);

			return this.bolPipelineStepDestinationMapper.MapBOToModel(this.dalPipelineStepDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepDestinationResponseModel> Get(int id)
		{
			var record = await pipelineStepDestinationRepository.Get(id);

			return this.bolPipelineStepDestinationMapper.MapBOToModel(this.dalPipelineStepDestinationMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPipelineStepDestinationResponseModel>> Create(
			ApiPipelineStepDestinationRequestModel model)
		{
			CreateResponse<ApiPipelineStepDestinationResponseModel> response = new CreateResponse<ApiPipelineStepDestinationResponseModel>(await this.pipelineStepDestinationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolPipelineStepDestinationMapper.MapModelToBO(default (int), model);
				var record = await this.pipelineStepDestinationRepository.Create(this.dalPipelineStepDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.bolPipelineStepDestinationMapper.MapBOToModel(this.dalPipelineStepDestinationMapper.MapEFToBO(record)));
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
				var bo = this.bolPipelineStepDestinationMapper.MapModelToBO(id, model);
				await this.pipelineStepDestinationRepository.Update(this.dalPipelineStepDestinationMapper.MapBOToEF(bo));
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
    <Hash>5269a7703d5bbf1b81fe8b28e50f98ea</Hash>
</Codenesium>*/