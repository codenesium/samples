using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractClientCommunicationService : AbstractService
	{
		protected IClientCommunicationRepository ClientCommunicationRepository { get; private set; }

		protected IApiClientCommunicationServerRequestModelValidator ClientCommunicationModelValidator { get; private set; }

		protected IBOLClientCommunicationMapper BolClientCommunicationMapper { get; private set; }

		protected IDALClientCommunicationMapper DalClientCommunicationMapper { get; private set; }

		private ILogger logger;

		public AbstractClientCommunicationService(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationServerRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper bolClientCommunicationMapper,
			IDALClientCommunicationMapper dalClientCommunicationMapper)
			: base()
		{
			this.ClientCommunicationRepository = clientCommunicationRepository;
			this.ClientCommunicationModelValidator = clientCommunicationModelValidator;
			this.BolClientCommunicationMapper = bolClientCommunicationMapper;
			this.DalClientCommunicationMapper = dalClientCommunicationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientCommunicationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ClientCommunicationRepository.All(limit, offset);

			return this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClientCommunicationServerResponseModel> Get(int id)
		{
			var record = await this.ClientCommunicationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiClientCommunicationServerResponseModel>> Create(
			ApiClientCommunicationServerRequestModel model)
		{
			CreateResponse<ApiClientCommunicationServerResponseModel> response = ValidationResponseFactory<ApiClientCommunicationServerResponseModel>.CreateResponse(await this.ClientCommunicationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolClientCommunicationMapper.MapModelToBO(default(int), model);
				var record = await this.ClientCommunicationRepository.Create(this.DalClientCommunicationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClientCommunicationServerResponseModel>> Update(
			int id,
			ApiClientCommunicationServerRequestModel model)
		{
			var validationResult = await this.ClientCommunicationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolClientCommunicationMapper.MapModelToBO(id, model);
				await this.ClientCommunicationRepository.Update(this.DalClientCommunicationMapper.MapBOToEF(bo));

				var record = await this.ClientCommunicationRepository.Get(id);

				return ValidationResponseFactory<ApiClientCommunicationServerResponseModel>.UpdateResponse(this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiClientCommunicationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.ClientCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.ClientCommunicationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d719684bfc32e2bd3468f39edb070556</Hash>
</Codenesium>*/