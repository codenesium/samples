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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOSalesOrderDetail: AbstractBOManager
	{
		private ISalesOrderDetailRepository salesOrderDetailRepository;
		private IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator;
		private IBOLSalesOrderDetailMapper salesOrderDetailMapper;
		private ILogger logger;

		public AbstractBOSalesOrderDetail(
			ILogger logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper salesOrderDetailMapper)
			: base()

		{
			this.salesOrderDetailRepository = salesOrderDetailRepository;
			this.salesOrderDetailModelValidator = salesOrderDetailModelValidator;
			this.salesOrderDetailMapper = salesOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderDetailRepository.All(skip, take, orderClause);

			return this.salesOrderDetailMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderDetailRepository.Get(salesOrderID);

			return this.salesOrderDetailMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
			ApiSalesOrderDetailRequestModel model)
		{
			CreateResponse<ApiSalesOrderDetailResponseModel> response = new CreateResponse<ApiSalesOrderDetailResponseModel>(await this.salesOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesOrderDetailMapper.MapModelToDTO(default (int), model);
				var record = await this.salesOrderDetailRepository.Create(dto);

				response.SetRecord(this.salesOrderDetailMapper.MapDTOToModel(record));
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
				var dto = this.salesOrderDetailMapper.MapModelToDTO(salesOrderID, model);
				await this.salesOrderDetailRepository.Update(salesOrderID, dto);
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
			List<DTOSalesOrderDetail> records = await this.salesOrderDetailRepository.GetProductID(productID);

			return this.salesOrderDetailMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>5ba3533bca7424daf5b36249f7538a75</Hash>
</Codenesium>*/