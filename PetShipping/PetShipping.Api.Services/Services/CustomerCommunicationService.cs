using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class CustomerCommunicationService : AbstractService, ICustomerCommunicationService
	{
		private MediatR.IMediator mediator;

		protected ICustomerCommunicationRepository CustomerCommunicationRepository { get; private set; }

		protected IApiCustomerCommunicationServerRequestModelValidator CustomerCommunicationModelValidator { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		private ILogger logger;

		public CustomerCommunicationService(
			ILogger<ICustomerCommunicationService> logger,
			MediatR.IMediator mediator,
			ICustomerCommunicationRepository customerCommunicationRepository,
			IApiCustomerCommunicationServerRequestModelValidator customerCommunicationModelValidator,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base()
		{
			this.CustomerCommunicationRepository = customerCommunicationRepository;
			this.CustomerCommunicationModelValidator = customerCommunicationModelValidator;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCustomerCommunicationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.All(limit, offset, query);

			return this.DalCustomerCommunicationMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCustomerCommunicationServerResponseModel> Get(int id)
		{
			CustomerCommunication record = await this.CustomerCommunicationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerCommunicationMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerCommunicationServerResponseModel>> Create(
			ApiCustomerCommunicationServerRequestModel model)
		{
			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.CreateResponse(await this.CustomerCommunicationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				CustomerCommunication record = this.DalCustomerCommunicationMapper.MapModelToEntity(default(int), model);
				record = await this.CustomerCommunicationRepository.Create(record);

				response.SetRecord(this.DalCustomerCommunicationMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CustomerCommunicationCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerCommunicationServerResponseModel>> Update(
			int id,
			ApiCustomerCommunicationServerRequestModel model)
		{
			var validationResult = await this.CustomerCommunicationModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				CustomerCommunication record = this.DalCustomerCommunicationMapper.MapModelToEntity(id, model);
				await this.CustomerCommunicationRepository.Update(record);

				record = await this.CustomerCommunicationRepository.Get(id);

				ApiCustomerCommunicationServerResponseModel apiModel = this.DalCustomerCommunicationMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CustomerCommunicationUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerCommunicationModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CustomerCommunicationRepository.Delete(id);

				await this.mediator.Publish(new CustomerCommunicationDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> ByCustomerId(int customerId, int limit = 0, int offset = int.MaxValue)
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.ByCustomerId(customerId, limit, offset);

			return this.DalCustomerCommunicationMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> ByEmployeeId(int employeeId, int limit = 0, int offset = int.MaxValue)
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.ByEmployeeId(employeeId, limit, offset);

			return this.DalCustomerCommunicationMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>d33cc712ba012ae2112fe1e51e29e851</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/