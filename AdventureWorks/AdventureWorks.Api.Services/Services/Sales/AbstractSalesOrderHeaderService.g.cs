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
		private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;
		private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;
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
			this.bolSalesOrderHeaderMapper = bolsalesOrderHeaderMapper;
			this.dalSalesOrderHeaderMapper = dalsalesOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderHeaderRepository.All(skip, take, orderClause);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderHeaderRepository.Get(salesOrderID);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> response = new CreateResponse<ApiSalesOrderHeaderResponseModel>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSalesOrderHeaderMapper.MapModelToBO(default (int), model);
				var record = await this.salesOrderHeaderRepository.Create(this.dalSalesOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record)));
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
				var bo = this.bolSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderHeaderRepository.Update(this.dalSalesOrderHeaderMapper.MapBOToEF(bo));
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

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record));
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetCustomerID(int customerID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.GetCustomerID(customerID);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}
		public async Task<List<ApiSalesOrderHeaderResponseModel>> GetSalesPersonID(Nullable<int> salesPersonID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.GetSalesPersonID(salesPersonID);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>1fe1fc7929e166fdfa7f8a7c4e946e32</Hash>
</Codenesium>*/