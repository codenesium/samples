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
	public abstract class AbstractClientCommunicationService : AbstractService
	{
		protected IClientCommunicationRepository ClientCommunicationRepository { get; private set; }

		protected IApiClientCommunicationRequestModelValidator ClientCommunicationModelValidator { get; private set; }

		protected IBOLClientCommunicationMapper BolClientCommunicationMapper { get; private set; }

		protected IDALClientCommunicationMapper DalClientCommunicationMapper { get; private set; }

		private ILogger logger;

		public AbstractClientCommunicationService(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
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

		public virtual async Task<List<ApiClientCommunicationResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.ClientCommunicationRepository.All(limit, offset);

			return this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiClientCommunicationResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
			ApiClientCommunicationRequestModel model)
		{
			CreateResponse<ApiClientCommunicationResponseModel> response = new CreateResponse<ApiClientCommunicationResponseModel>(await this.ClientCommunicationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolClientCommunicationMapper.MapModelToBO(default(int), model);
				var record = await this.ClientCommunicationRepository.Create(this.DalClientCommunicationMapper.MapBOToEF(bo));

				response.SetRecord(this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiClientCommunicationResponseModel>> Update(
			int id,
			ApiClientCommunicationRequestModel model)
		{
			var validationResult = await this.ClientCommunicationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolClientCommunicationMapper.MapModelToBO(id, model);
				await this.ClientCommunicationRepository.Update(this.DalClientCommunicationMapper.MapBOToEF(bo));

				var record = await this.ClientCommunicationRepository.Get(id);

				return new UpdateResponse<ApiClientCommunicationResponseModel>(this.BolClientCommunicationMapper.MapBOToModel(this.DalClientCommunicationMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiClientCommunicationResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.ClientCommunicationModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.ClientCommunicationRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>34800fc0dcd85b8e21e882ea50278e73</Hash>
</Codenesium>*/