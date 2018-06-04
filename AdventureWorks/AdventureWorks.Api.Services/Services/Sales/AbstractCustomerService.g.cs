using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractCustomerService: AbstractService
	{
		private ICustomerRepository customerRepository;
		private IApiCustomerRequestModelValidator customerModelValidator;
		private IBOLCustomerMapper BOLCustomerMapper;
		private IDALCustomerMapper DALCustomerMapper;
		private ILogger logger;

		public AbstractCustomerService(
			ILogger logger,
			ICustomerRepository customerRepository,
			IApiCustomerRequestModelValidator customerModelValidator,
			IBOLCustomerMapper bolcustomerMapper,
			IDALCustomerMapper dalcustomerMapper)
			: base()

		{
			this.customerRepository = customerRepository;
			this.customerModelValidator = customerModelValidator;
			this.BOLCustomerMapper = bolcustomerMapper;
			this.DALCustomerMapper = dalcustomerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.customerRepository.All(skip, take, orderClause);

			return this.BOLCustomerMapper.MapBOToModel(this.DALCustomerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerResponseModel> Get(int customerID)
		{
			var record = await customerRepository.Get(customerID);

			return this.BOLCustomerMapper.MapBOToModel(this.DALCustomerMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model)
		{
			CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLCustomerMapper.MapModelToBO(default (int), model);
				var record = await this.customerRepository.Create(this.DALCustomerMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLCustomerMapper.MapBOToModel(this.DALCustomerMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int customerID,
			ApiCustomerRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateUpdateAsync(customerID, model));

			if (response.Success)
			{
				var bo = this.BOLCustomerMapper.MapModelToBO(customerID, model);
				await this.customerRepository.Update(this.DALCustomerMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int customerID)
		{
			ActionResponse response = new ActionResponse(await this.customerModelValidator.ValidateDeleteAsync(customerID));

			if (response.Success)
			{
				await this.customerRepository.Delete(customerID);
			}
			return response;
		}

		public async Task<ApiCustomerResponseModel> GetAccountNumber(string accountNumber)
		{
			Customer record = await this.customerRepository.GetAccountNumber(accountNumber);

			return this.BOLCustomerMapper.MapBOToModel(this.DALCustomerMapper.MapEFToBO(record));
		}
		public async Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID)
		{
			List<Customer> records = await this.customerRepository.GetTerritoryID(territoryID);

			return this.BOLCustomerMapper.MapBOToModel(this.DALCustomerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>a4294dc7c6fb5e5595bf4af7358ab1e5</Hash>
</Codenesium>*/