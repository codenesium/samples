using MediatR;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractCustomerCommunicationService : AbstractService
	{
		private IMediator mediator;

		protected ICustomerCommunicationRepository CustomerCommunicationRepository { get; private set; }

		protected IApiCustomerCommunicationServerRequestModelValidator CustomerCommunicationModelValidator { get; private set; }

		protected IBOLCustomerCommunicationMapper BolCustomerCommunicationMapper { get; private set; }

		protected IDALCustomerCommunicationMapper DalCustomerCommunicationMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerCommunicationService(
			ILogger logger,
			IMediator mediator,
			ICustomerCommunicationRepository customerCommunicationRepository,
			IApiCustomerCommunicationServerRequestModelValidator customerCommunicationModelValidator,
			IBOLCustomerCommunicationMapper bolCustomerCommunicationMapper,
			IDALCustomerCommunicationMapper dalCustomerCommunicationMapper)
			: base()
		{
			this.CustomerCommunicationRepository = customerCommunicationRepository;
			this.CustomerCommunicationModelValidator = customerCommunicationModelValidator;
			this.BolCustomerCommunicationMapper = bolCustomerCommunicationMapper;
			this.DalCustomerCommunicationMapper = dalCustomerCommunicationMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCustomerCommunicationServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CustomerCommunicationRepository.All(limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerCommunicationServerResponseModel> Get(int id)
		{
			var record = await this.CustomerCommunicationRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerCommunicationServerResponseModel>> Create(
			ApiCustomerCommunicationServerRequestModel model)
		{
			CreateResponse<ApiCustomerCommunicationServerResponseModel> response = ValidationResponseFactory<ApiCustomerCommunicationServerResponseModel>.CreateResponse(await this.CustomerCommunicationModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolCustomerCommunicationMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerCommunicationRepository.Create(this.DalCustomerCommunicationMapper.MapBOToEF(bo));

				var businessObject = this.DalCustomerCommunicationMapper.MapEFToBO(record);
				response.SetRecord(this.BolCustomerCommunicationMapper.MapBOToModel(businessObject));
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
				var bo = this.BolCustomerCommunicationMapper.MapModelToBO(id, model);
				await this.CustomerCommunicationRepository.Update(this.DalCustomerCommunicationMapper.MapBOToEF(bo));

				var record = await this.CustomerCommunicationRepository.Get(id);

				var businessObject = this.DalCustomerCommunicationMapper.MapEFToBO(record);
				var apiModel = this.BolCustomerCommunicationMapper.MapBOToModel(businessObject);
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

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCustomerCommunicationServerResponseModel>> ByEmployeeId(int employeeId, int limit = 0, int offset = int.MaxValue)
		{
			List<CustomerCommunication> records = await this.CustomerCommunicationRepository.ByEmployeeId(employeeId, limit, offset);

			return this.BolCustomerCommunicationMapper.MapBOToModel(this.DalCustomerCommunicationMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8ae288d41ac4607d1474465be9590863</Hash>
</Codenesium>*/