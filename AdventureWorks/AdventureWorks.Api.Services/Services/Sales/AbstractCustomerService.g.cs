using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCustomerService : AbstractService
	{
		private IMediator mediator;

		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerServerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			IMediator mediator,
			ICustomerRepository customerRepository,
			IApiCustomerServerRequestModelValidator customerModelValidator,
			IDALCustomerMapper dalCustomerMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.DalCustomerMapper = dalCustomerMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiCustomerServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Customer> records = await this.CustomerRepository.All(limit, offset, query);

			return this.DalCustomerMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiCustomerServerResponseModel> Get(int customerID)
		{
			Customer record = await this.CustomerRepository.Get(customerID);

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
			int customerID,
			ApiCustomerServerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(customerID, model);

			if (validationResult.IsValid)
			{
				Customer record = this.DalCustomerMapper.MapModelToEntity(customerID, model);
				await this.CustomerRepository.Update(record);

				record = await this.CustomerRepository.Get(customerID);

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
			int customerID)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(customerID));

			if (response.Success)
			{
				await this.CustomerRepository.Delete(customerID);

				await this.mediator.Publish(new CustomerDeletedNotification(customerID));
			}

			return response;
		}

		public async virtual Task<ApiCustomerServerResponseModel> ByAccountNumber(string accountNumber)
		{
			Customer record = await this.CustomerRepository.ByAccountNumber(accountNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<ApiCustomerServerResponseModel> ByRowguid(Guid rowguid)
		{
			Customer record = await this.CustomerRepository.ByRowguid(rowguid);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalCustomerMapper.MapEntityToModel(record);
			}
		}

		public async virtual Task<List<ApiCustomerServerResponseModel>> ByTerritoryID(int? territoryID, int limit = 0, int offset = int.MaxValue)
		{
			List<Customer> records = await this.CustomerRepository.ByTerritoryID(territoryID, limit, offset);

			return this.DalCustomerMapper.MapEntityToModel(records);
		}

		public async virtual Task<List<ApiSalesOrderHeaderServerResponseModel>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CustomerRepository.SalesOrderHeadersByCustomerID(customerID, limit, offset);

			return this.DalSalesOrderHeaderMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>4d693d94b553aa4350c2954a60b14f31</Hash>
</Codenesium>*/