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
	public abstract class AbstractSalesOrderDetailService: AbstractService
	{
		private ISalesOrderDetailRepository salesOrderDetailRepository;
		private IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator;
		private IBOLSalesOrderDetailMapper BOLSalesOrderDetailMapper;
		private IDALSalesOrderDetailMapper DALSalesOrderDetailMapper;
		private ILogger logger;

		public AbstractSalesOrderDetailService(
			ILogger logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper bolsalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalsalesOrderDetailMapper)
			: base()

		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
			this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
			this.BOLSalesOrderDetailMapper = bolsalesOrderDetailMapper;
			this.DALSalesOrderDetailMapper = dalsalesOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderDetailRepository.All(skip, take, orderClause);

			return this.BOLSalesOrderDetailMapper.MapBOToModel(this.DALSalesOrderDetailMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderDetailRepository.Get(salesOrderID);

			return this.BOLSalesOrderDetailMapper.MapBOToModel(this.DALSalesOrderDetailMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
			ApiSalesOrderDetailRequestModel model)
		{
			CreateResponse<ApiSalesOrderDetailResponseModel> response = new CreateResponse<ApiSalesOrderDetailResponseModel>(await this.salesOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesOrderDetailMapper.MapModelToBO(default (int), model);
				var record = await this.salesOrderDetailRepository.Create(this.DALSalesOrderDetailMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesOrderDetailMapper.MapBOToModel(this.DALSalesOrderDetailMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesOrderDetailMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderDetailRepository.Update(this.DALSalesOrderDetailMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderDetailModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderDetailRepository.Delete(salesOrderID);
			}
			return response;
		}

		public async Task<List<ApiSalesOrderDetailResponseModel>> GetProductID(int productID)
		{
			List<SalesOrderDetail> records = await this.salesOrderDetailRepository.GetProductID(productID);

			return this.BOLSalesOrderDetailMapper.MapBOToModel(this.DALSalesOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>5f5d8133801d9145515b51d83b8b2d5b</Hash>
</Codenesium>*/