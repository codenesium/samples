using Microsoft.Extensions.Logging;
using PointOfSaleNS.Api.Contracts;
using PointOfSaleNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PointOfSaleNS.Api.Services
{
	public class CustomerService : AbstractService, ICustomerService
	{
		private MediatR.IMediator mediator;

		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerServerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		private ILogger logger;

		public CustomerService(
			ILogger<ICustomerService> logger,
			MediatR.IMediator mediator,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IDALCustomerMapper dalCustomerMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.DalCustomerMapper = dalCustomerMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCustomerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Customer> records = await this.CustomerRepository.All(limit, offset, query);

			return this.DalCustomerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCustomerServerResponseModel> Get(int id)
		{
			Customer record = await this.CustomerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerServerResponseModel>> Create(
			ApiCustomerServerRequestModel model)
		{
			CreateResponse<ApiCustomerServerResponseModel> response = ValidationResponseFactory<ApiCustomerServerResponseModel>.CreateResponse(await this.CustomerModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Customer record = this.DalCustomerMapper.MapModelToEntity(default(int), model);
				record = await this.CustomerRepository.Create(record);

				response.SetRecord(this.DalCustomerMapper.MapEntityToModel(record));
				await this.mediator.Publish(new CustomerCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerServerResponseModel>> Update(
			int id,
			ApiCustomerServerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				Customer record = this.DalCustomerMapper.MapModelToEntity(id, model);
				await this.CustomerRepository.Update(record);

				record = await this.CustomerRepository.Get(id);

				ApiCustomerServerResponseModel apiModel = this.DalCustomerMapper.MapEntityToModel(record);
				await this.mediator.Publish(new CustomerUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiCustomerServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.CustomerRepository.Delete(id);

				await this.mediator.Publish(new CustomerDeletedNotification(id));
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>57fcaf1e3ddc9dafcc82a1dc34911875</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/