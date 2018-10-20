using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCustomerService : AbstractService
	{
		protected ICustomerRepository CustomerRepository { get; private set; }

		protected IApiCustomerRequestModelValidator CustomerModelValidator { get; private set; }

		protected IBOLCustomerMapper BolCustomerMapper { get; private set; }

		protected IDALCustomerMapper DalCustomerMapper { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolCustomerMapper,
			IDALCustomerMapper dalCustomerMapper,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper)
			: base()
		{
			this.CustomerRepository = customerRepository;
			this.CustomerModelValidator = customerModelValidator;
			this.BolCustomerMapper = bolCustomerMapper;
			this.DalCustomerMapper = dalCustomerMapper;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CustomerRepository.All(limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerResponseModel> Get(int customerID)
		{
			var record = await this.CustomerRepository.Get(customerID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model)
		{
			CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.CustomerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(default(int), model);
				var record = await this.CustomerRepository.Create(this.DalCustomerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCustomerResponseModel>> Update(
			int customerID,
			ApiCustomerRequestModel model)
		{
			var validationResult = await this.CustomerModelValidator.ValidateUpdateAsync(customerID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCustomerMapper.MapModelToBO(customerID, model);
				await this.CustomerRepository.Update(this.DalCustomerMapper.MapBOToEF(bo));

				var record = await this.CustomerRepository.Get(customerID);

				return new UpdateResponse<ApiCustomerResponseModel>(this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCustomerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int customerID)
		{
			ActionResponse response = new ActionResponse(await this.CustomerModelValidator.ValidateDeleteAsync(customerID));
			if (response.Success)
			{
				await this.CustomerRepository.Delete(customerID);
			}

			return response;
		}

		public async Task<ApiCustomerResponseModel> ByAccountNumber(string accountNumber)
		{
			Customer record = await this.CustomerRepository.ByAccountNumber(accountNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiCustomerResponseModel>> ByTerritoryID(int? territoryID, int limit = 0, int offset = int.MaxValue)
		{
			List<Customer> records = await this.CustomerRepository.ByTerritoryID(territoryID, limit, offset);

			return this.BolCustomerMapper.MapBOToModel(this.DalCustomerMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> SalesOrderHeadersByCustomerID(int customerID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.CustomerRepository.SalesOrderHeadersByCustomerID(customerID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>64d4f618d37cd907ff3a73a60628cc80</Hash>
</Codenesium>*/