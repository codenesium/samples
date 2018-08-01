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
	public abstract class AbstractSalesOrderHeaderService : AbstractService
	{
		private ISalesOrderHeaderRepository salesOrderHeaderRepository;

		private IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator;

		private IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper;

		private IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper;

		private IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper;

		private IDALSalesOrderDetailMapper dalSalesOrderDetailMapper;
		private IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper;

		private IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper;

		private ILogger logger;

		public AbstractSalesOrderHeaderService(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper,
			IBOLSalesOrderHeaderSalesReasonMapper bolSalesOrderHeaderSalesReasonMapper,
			IDALSalesOrderHeaderSalesReasonMapper dalSalesOrderHeaderSalesReasonMapper)
			: base()
		{
			this.salesOrderHeaderRepository = salesOrderHeaderRepository;
			this.salesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.bolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.dalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.bolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
			this.dalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
			this.bolSalesOrderHeaderSalesReasonMapper = bolSalesOrderHeaderSalesReasonMapper;
			this.dalSalesOrderHeaderSalesReasonMapper = dalSalesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.salesOrderHeaderRepository.All(limit, offset);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID)
		{
			var record = await this.salesOrderHeaderRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> response = new CreateResponse<ApiSalesOrderHeaderResponseModel>(await this.salesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolSalesOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.salesOrderHeaderRepository.Create(this.dalSalesOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model)
		{
			var validationResult = await this.salesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.salesOrderHeaderRepository.Update(this.dalSalesOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.salesOrderHeaderRepository.Get(salesOrderID);

				return new UpdateResponse<ApiSalesOrderHeaderResponseModel>(this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesOrderHeaderResponseModel>(validationResult);
			}
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

		public async Task<ApiSalesOrderHeaderResponseModel> BySalesOrderNumber(string salesOrderNumber)
		{
			SalesOrderHeader record = await this.salesOrderHeaderRepository.BySalesOrderNumber(salesOrderNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiSalesOrderHeaderResponseModel>> ByCustomerID(int customerID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.ByCustomerID(customerID);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async Task<List<ApiSalesOrderHeaderResponseModel>> BySalesPersonID(int? salesPersonID)
		{
			List<SalesOrderHeader> records = await this.salesOrderHeaderRepository.BySalesPersonID(salesPersonID);

			return this.bolSalesOrderHeaderMapper.MapBOToModel(this.dalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderDetail> records = await this.salesOrderHeaderRepository.SalesOrderDetails(salesOrderID, limit, offset);

			return this.bolSalesOrderDetailMapper.MapBOToModel(this.dalSalesOrderDetailMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> SalesOrderHeaderSalesReasons(int salesOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeaderSalesReason> records = await this.salesOrderHeaderRepository.SalesOrderHeaderSalesReasons(salesOrderID, limit, offset);

			return this.bolSalesOrderHeaderSalesReasonMapper.MapBOToModel(this.dalSalesOrderHeaderSalesReasonMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b89d2e6a50fceb86378b77ec1c615276</Hash>
</Codenesium>*/