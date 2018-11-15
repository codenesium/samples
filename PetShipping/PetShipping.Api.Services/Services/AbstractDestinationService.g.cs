using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractDestinationService : AbstractService
	{
		protected IDestinationRepository DestinationRepository { get; private set; }

		protected IApiDestinationServerRequestModelValidator DestinationModelValidator { get; private set; }

		protected IBOLDestinationMapper BolDestinationMapper { get; private set; }

		protected IDALDestinationMapper DalDestinationMapper { get; private set; }

		protected IBOLPipelineStepDestinationMapper BolPipelineStepDestinationMapper { get; private set; }

		protected IDALPipelineStepDestinationMapper DalPipelineStepDestinationMapper { get; private set; }

		private ILogger logger;

		public AbstractDestinationService(
			ILogger logger,
			IDestinationRepository destinationRepository,
			IApiDestinationServerRequestModelValidator destinationModelValidator,
			IBOLDestinationMapper bolDestinationMapper,
			IDALDestinationMapper dalDestinationMapper,
			IBOLPipelineStepDestinationMapper bolPipelineStepDestinationMapper,
			IDALPipelineStepDestinationMapper dalPipelineStepDestinationMapper)
			: base()
		{
			this.DestinationRepository = destinationRepository;
			this.DestinationModelValidator = destinationModelValidator;
			this.BolDestinationMapper = bolDestinationMapper;
			this.DalDestinationMapper = dalDestinationMapper;
			this.BolPipelineStepDestinationMapper = bolPipelineStepDestinationMapper;
			this.DalPipelineStepDestinationMapper = dalPipelineStepDestinationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiDestinationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.DestinationRepository.All(limit, offset);

			return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiDestinationServerResponseModel> Get(int id)
		{
			var record = await this.DestinationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiDestinationServerResponseModel>> Create(
			ApiDestinationServerRequestModel model)
		{
			CreateResponse<ApiDestinationServerResponseModel> response = ValidationResponseFactory<ApiDestinationServerResponseModel>.CreateResponse(await this.DestinationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(default(int), model);
				var record = await this.DestinationRepository.Create(this.DalDestinationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiDestinationServerResponseModel>> Update(
			int id,
			ApiDestinationServerRequestModel model)
		{
			var validationResult = await this.DestinationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolDestinationMapper.MapModelToBO(id, model);
				await this.DestinationRepository.Update(this.DalDestinationMapper.MapBOToEF(bo));

				var record = await this.DestinationRepository.Get(id);

				return ValidationResponseFactory<ApiDestinationServerResponseModel>.UpdateResponse(this.BolDestinationMapper.MapBOToModel(this.DalDestinationMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiDestinationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.DestinationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.DestinationRepository.Delete(id);
			}

			return response;
		}

		public async virtual Task<List<ApiPipelineStepDestinationServerResponseModel>> PipelineStepDestinationsByDestinationId(int destinationId, int limit = int.MaxValue, int offset = 0)
		{
			List<PipelineStepDestination> records = await this.DestinationRepository.PipelineStepDestinationsByDestinationId(destinationId, limit, offset);

			return this.BolPipelineStepDestinationMapper.MapBOToModel(this.DalPipelineStepDestinationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a1d93bb7742548f14f6b2847da64003e</Hash>
</Codenesium>*/