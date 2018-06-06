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
		private IBOLCustomerMapper bolCustomerMapper;
		private IDALCustomerMapper dalCustomerMapper;
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
			this.bolCustomerMapper = bolcustomerMapper;
			this.dalCustomerMapper = dalcustomerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCustomerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.customerRepository.All(skip, take, orderClause);

			return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCustomerResponseModel> Get(int customerID)
		{
			var record = await customerRepository.Get(customerID);

			return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiCustomerResponseModel>> Create(
			ApiCustomerRequestModel model)
		{
			CreateResponse<ApiCustomerResponseModel> response = new CreateResponse<ApiCustomerResponseModel>(await this.customerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolCustomerMapper.MapModelToBO(default (int), model);
				var record = await this.customerRepository.Create(this.dalCustomerMapper.MapBOToEF(bo));

				response.SetRecord(this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record)));
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
				var bo = this.bolCustomerMapper.MapModelToBO(customerID, model);
				await this.customerRepository.Update(this.dalCustomerMapper.MapBOToEF(bo));
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

			return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(record));
		}
		public async Task<List<ApiCustomerResponseModel>> GetTerritoryID(Nullable<int> territoryID)
		{
			List<Customer> records = await this.customerRepository.GetTerritoryID(territoryID);

			return this.bolCustomerMapper.MapBOToModel(this.dalCustomerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>85f54138c99cc28514e8dcd23e9bf151</Hash>
</Codenesium>*/