using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStepStatuService : AbstractService
	{
		protected IPipelineStepStatuRepository PipelineStepStatuRepository { get; private set; }

		protected IApiPipelineStepStatuServerRequestModelValidator PipelineStepStatuModelValidator { get; private set; }

		protected IBOLPipelineStepStatuMapper BolPipelineStepStatuMapper { get; private set; }

		protected IDALPipelineStepStatuMapper DalPipelineStepStatuMapper { get; private set; }

		protected IBOLPipelineStepMapper BolPipelineStepMapper { get; private set; }

		protected IDALPipelineStepMapper DalPipelineStepMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStepStatuService(
			ILogger logger,
			IPipelineStepStatuRepository pipelineStepStatuRepository,
			IApiPipelineStepStatuServerRequestModelValidator pipelineStepStatuModelValidator,
			IBOLPipelineStepStatuMapper bolPipelineStepStatuMapper,
			IDALPipelineStepStatuMapper dalPipelineStepStatuMapper,
			IBOLPipelineStepMapper bolPipelineStepMapper,
			IDALPipelineStepMapper dalPipelineStepMapper)
			: base()
		{
			this.PipelineStepStatuRepository = pipelineStepStatuRepository;
			this.PipelineStepStatuModelValidator = pipelineStepStatuModelValidator;
			this.BolPipelineStepStatuMapper = bolPipelineStepStatuMapper;
			this.DalPipelineStepStatuMapper = dalPipelineStepStatuMapper;
			this.BolPipelineStepMapper = bolPipelineStepMapper;
			this.DalPipelineStepMapper = dalPipelineStepMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStepStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStepStatuRepository.All(limit, offset);

			return this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStepStatuServerResponseModel> Get(int id)
		{
			var record = await this.PipelineStepStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStepStatuServerResponseModel>> Create(
			ApiPipelineStepStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStepStatuServerResponseModel> response = ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.CreateResponse(await this.PipelineStepStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStepStatuMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStepStatuRepository.Create(this.DalPipelineStepStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStepStatuServerResponseModel>> Update(
			int id,
			ApiPipelineStepStatuServerRequestModel model)
		{
			var validationResult = await this.PipelineStepStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStepStatuMapper.MapModelToBO(id, model);
				await this.PipelineStepStatuRepository.Update(this.DalPipelineStepStatuMapper.MapBOToEF(bo));

				var record = await this.PipelineStepStatuRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.UpdateResponse(this.BolPipelineStepStatuMapper.MapBOToModel(this.DalPipelineStepStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStepStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStepStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStepStatuRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepServerResponseModel>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStep> records = await this.PipelineStepStatuRepository.PipelineStepsByPipelineStepStatusId(pipelineStepStatusId, limit, offset);

			return this.BolPipelineStepMapper.MapBOToModel(this.DalPipelineStepMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>48e186ddd5d2116015acc00e8371947a</Hash>
</Codenesium>*/