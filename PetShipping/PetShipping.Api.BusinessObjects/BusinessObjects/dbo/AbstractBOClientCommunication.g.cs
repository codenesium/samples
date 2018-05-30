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
	public abstract class AbstractBOClientCommunication: AbstractBOManager
	{
		private IClientCommunicationRepository clientCommunicationRepository;
		private IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator;
		private IBOLClientCommunicationMapper clientCommunicationMapper;
		private ILogger logger;

		public AbstractBOClientCommunication(
			ILogger logger,
			IClientCommunicationRepository clientCommunicationRepository,
			IApiClientCommunicationRequestModelValidator clientCommunicationModelValidator,
			IBOLClientCommunicationMapper clientCommunicationMapper)
			: base()

		{
			this.clientCommunicationRepository = clientCommunicationRepository;
			this.clientCommunicationModelValidator = clientCommunicationModelValidator;
			this.clientCommunicationMapper = clientCommunicationMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiClientCommunicationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.clientCommunicationRepository.All(skip, take, orderClause);

			return this.clientCommunicationMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiClientCommunicationResponseModel> Get(int id)
		{
			var record = await clientCommunicationRepository.Get(id);

			return this.clientCommunicationMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiClientCommunicationResponseModel>> Create(
			ApiClientCommunicationRequestModel model)
		{
			CreateResponse<ApiClientCommunicationResponseModel> response = new CreateResponse<ApiClientCommunicationResponseModel>(await this.clientCommunicationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.clientCommunicationMapper.MapModelToDTO(default (int), model);
				var record = await this.clientCommunicationRepository.Create(dto);

				response.SetRecord(this.clientCommunicationMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiClientCommunicationRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				var dto = this.clientCommunicationMapper.MapModelToDTO(id, model);
				await this.clientCommunicationRepository.Update(id, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.clientCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.clientCommunicationRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>221fcf7f69dddf7173edd8b5b26fc4fb</Hash>
</Codenesium>*/