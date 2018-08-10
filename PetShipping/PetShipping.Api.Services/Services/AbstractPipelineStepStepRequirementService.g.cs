using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepStepRequirementService : AbstractService
	{
		protected IPipelineStepStepRequirementRepository PipelineStepStepRequirementRepository { get; private set; }

		protected IApiPipelineStepStepRequirementRequestModelValidator PipelineStepStepRequirementModelValidator { get; private set; }

		protected IBOLPipelineStepStepRequirementMapper BolPipelineStepStepRequirementMapper { get; private set; }

		protected IDALPipelineStepStepRequirementMapper DalPipelineStepStepRequirementMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStepRequirementService(
			ILogger logger,
			IPipelineStepStepRequirementRepository pipelineStepStepRequirementRepository,
			IApiPipelineStepStepRequirementRequestModelValidator pipelineStepStepRequirementModelValidator,
			IBOLPipelineStepStepRequirementMapper bolPipelineStepStepRequirementMapper,
			IDALPipelineStepStepRequirementMapper dalPipelineStepStepRequirementMapper)
			: base()
		{
			this.PipelineStepStepRequirementRepository = pipelineStepStepRequirementRepository;
			this.PipelineStepStepRequirementModelValidator = pipelineStepStepRequirementModelValidator;
			this.BolPipelineStepStepRequirementMapper = bolPipelineStepStepRequirementMapper;
			this.DalPipelineStepStepRequirementMapper = dalPipelineStepStepRequirementMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStepRequirementResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepStepRequirementRepository.All(limit, offset);

			return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepStepRequirementResponseModel> Get(int id)
		{
			var record = await this.PipelineStepStepRequirementRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStepRequirementResponseModel>> Create(
			ApiPipelineStepStepRequirementRequestModel model)
		{
			CreateResponse<ApiPipelineStepStepRequirementResponseModel> response = new CreateResponse<ApiPipelineStepStepRequirementResponseModel>(await this.PipelineStepStepRequirementModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPipelineStepStepRequirementMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepStepRequirementRepository.Create(this.DalPipelineStepStepRequirementMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStepRequirementResponseModel>> Update(
			int id,
			ApiPipelineStepStepRequirementRequestModel model)
		{
			var validationResult = await this.PipelineStepStepRequirementModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepStepRequirementMapper.MapModelToBO(id, model);
				await this.PipelineStepStepRequirementRepository.Update(this.DalPipelineStepStepRequirementMapper.MapBOToEF(bo));

				var record = await this.PipelineStepStepRequirementRepository.Get(id);

				return new UpdateResponse<ApiPipelineStepStepRequirementResponseModel>(this.BolPipelineStepStepRequirementMapper.MapBOToModel(this.DalPipelineStepStepRequirementMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPipelineStepStepRequirementResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.PipelineStepStepRequirementModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.PipelineStepStepRequirementRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>817f76167883ce94c978e9ef5395fab4</Hash>
</Codenesium>*/