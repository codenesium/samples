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
	public abstract class AbstractSalesOrderHeaderService: AbstractService
	{
		private ISalesOrderHeaderRepository salesOrderHeaderRepository;
		private IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator;
		private IBOLSalesOrderHeaderMapper BOLSalesOrderHeaderMapper;
		private IDALSalesOrderHeaderMapper DALSalesOrderHeaderMapper;
		private ILogger logger;

		public AbstractSalesOrderHeaderService(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolsalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalsalesOrderHeaderMapper)
			: base()

		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.BOLSalesOrderHeaderMapper = bolsalesOrderHeaderMapper;
			this.DALSalesOrderHeaderMapper = dalsalesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderHeaderRepository.All(skip, take, orderClause);

			return this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderHeaderRepository.Get(salesOrderID);

			return this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> response = new CreateResponse<ApiSalesOrderHeaderResponseModel>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesOrderHeaderMapper.MapModelToBO(default (int), model);
				var record = await this.salesOrderHeaderRepository.Create(this.DALSalesOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderHeaderRepository.Update(this.DALSalesOrderHeaderMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderHeaderRepository.Delete(salesOrderID);
			}
			return response;
		}

		public async Task<ApiSalesOrderHeaderResponseModel> GetSalesOrderNumber(string salesOrderNumber)
		{
			SalesOrderHeader record = await this.salesOrderHeaderRepository.GetSalesOrderNumber(salesOrderNumber);

			return this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(record));
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetCustomerID(int customerID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.GetCustomerID(customerID);

			return this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(records));
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.GetSalesPersonID(salesPersonID);

			return this.BOLSalesOrderHeaderMapper.MapBOToModel(this.DALSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>ccc4ef9cb63b396916c20235245be570</Hash>
</Codenesium>*/