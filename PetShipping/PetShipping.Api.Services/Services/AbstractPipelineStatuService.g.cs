using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractPipelineStatuService : AbstractService
	{
		protected IPipelineStatuRepository PipelineStatuRepository { get; private set; }

		protected IApiPipelineStatuServerRequestModelValidator PipelineStatuModelValidator { get; private set; }

		protected IBOLPipelineStatuMapper BolPipelineStatuMapper { get; private set; }

		protected IDALPipelineStatuMapper DalPipelineStatuMapper { get; private set; }

		protected IBOLPipelineMapper BolPipelineMapper { get; private set; }

		protected IDALPipelineMapper DalPipelineMapper { get; private set; }

		private ILogger logger;

		public AbstractPipelineStatuService(
			ILogger logger,
			IPipelineStatuRepository pipelineStatuRepository,
			IApiPipelineStatuServerRequestModelValidator pipelineStatuModelValidator,
			IBOLPipelineStatuMapper bolPipelineStatuMapper,
			IDALPipelineStatuMapper dalPipelineStatuMapper,
			IBOLPipelineMapper bolPipelineMapper,
			IDALPipelineMapper dalPipelineMapper)
			: base()
		{
			this.PipelineStatuRepository = pipelineStatuRepository;
			this.PipelineStatuModelValidator = pipelineStatuModelValidator;
			this.BolPipelineStatuMapper = bolPipelineStatuMapper;
			this.DalPipelineStatuMapper = dalPipelineStatuMapper;
			this.BolPipelineMapper = bolPipelineMapper;
			this.DalPipelineMapper = dalPipelineMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPipelineStatuServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PipelineStatuRepository.All(limit, offset);

			return this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPipelineStatuServerResponseModel> Get(int id)
		{
			var record = await this.PipelineStatuRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPipelineStatuServerResponseModel>> Create(
			ApiPipelineStatuServerRequestModel model)
		{
			CreateResponse<ApiPipelineStatuServerResponseModel> response = ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.CreateResponse(await this.PipelineStatuModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolPipelineStatuMapper.MapModelToBO(default(int), model);
				var record = await this.PipelineStatuRepository.Create(this.DalPipelineStatuMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPipelineStatuServerResponseModel>> Update(
			int id,
			ApiPipelineStatuServerRequestModel model)
		{
			var validationResult = await this.PipelineStatuModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPipelineStatuMapper.MapModelToBO(id, model);
				await this.PipelineStatuRepository.Update(this.DalPipelineStatuMapper.MapBOToEF(bo));

				var record = await this.PipelineStatuRepository.Get(id);

				return ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.UpdateResponse(this.BolPipelineStatuMapper.MapBOToModel(this.DalPipelineStatuMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiPipelineStatuServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.PipelineStatuModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.PipelineStatuRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineServerResponseModel>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0)
		{
			List<Pipeline> records = await this.PipelineStatuRepository.PipelinesByPipelineStatusId(pipelineStatusId, limit, offset);

			return this.BolPipelineMapper.MapBOToModel(this.DalPipelineMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>3187cbce747db689fc539345c740b60e</Hash>
</Codenesium>*/