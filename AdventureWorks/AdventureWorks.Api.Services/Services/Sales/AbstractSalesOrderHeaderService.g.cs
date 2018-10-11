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
		protected ISalesOrderHeaderRepository SalesOrderHeaderRepository { get; private set; }

		protected IApiSalesOrderHeaderRequestModelValidator SalesOrderHeaderModelValidator { get; private set; }

		protected IBOLSalesOrderHeaderMapper BolSalesOrderHeaderMapper { get; private set; }

		protected IDALSalesOrderHeaderMapper DalSalesOrderHeaderMapper { get; private set; }

		protected IBOLSalesOrderDetailMapper BolSalesOrderDetailMapper { get; private set; }

		protected IDALSalesOrderDetailMapper DalSalesOrderDetailMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesOrderHeaderService(
			ILogger logger,
			ISalesOrderHeaderRepository salesOrderHeaderRepository,
			IApiSalesOrderHeaderRequestModelValidator salesOrderHeaderModelValidator,
			IBOLSalesOrderHeaderMapper bolSalesOrderHeaderMapper,
			IDALSalesOrderHeaderMapper dalSalesOrderHeaderMapper,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
			: base()
		{
			this.SalesOrderHeaderRepository = salesOrderHeaderRepository;
			this.SalesOrderHeaderModelValidator = salesOrderHeaderModelValidator;
			this.BolSalesOrderHeaderMapper = bolSalesOrderHeaderMapper;
			this.DalSalesOrderHeaderMapper = dalSalesOrderHeaderMapper;
			this.BolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
			this.DalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesOrderHeaderRepository.All(limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderHeaderResponseModel> Get(int salesOrderID)
		{
			var record = await this.SalesOrderHeaderRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderResponseModel>> Create(
			ApiSalesOrderHeaderRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderResponseModel> response = new CreateResponse<ApiSalesOrderHeaderResponseModel>(await this.SalesOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesOrderHeaderMapper.MapModelToBO(default(int), model);
				var record = await this.SalesOrderHeaderRepository.Create(this.DalSalesOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderHeaderResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderHeaderRequestModel model)
		{
			var validationResult = await this.SalesOrderHeaderModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesOrderHeaderMapper.MapModelToBO(salesOrderID, model);
				await this.SalesOrderHeaderRepository.Update(this.DalSalesOrderHeaderMapper.MapBOToEF(bo));

				var record = await this.SalesOrderHeaderRepository.Get(salesOrderID);

				return new UpdateResponse<ApiSalesOrderHeaderResponseModel>(this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesOrderHeaderResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.SalesOrderHeaderModelValidator.ValidateDeleteAsync(salesOrderID));
			if (response.Success)
			{
				await this.SalesOrderHeaderRepository.Delete(salesOrderID);
			}

			return response;
		}

		public async Task<ApiSalesOrderHeaderResponseModel> BySalesOrderNumber(string salesOrderNumber)
		{
			SalesOrderHeader record = await this.SalesOrderHeaderRepository.BySalesOrderNumber(salesOrderNumber);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiSalesOrderHeaderResponseModel>> ByCustomerID(int customerID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.ByCustomerID(customerID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async Task<List<ApiSalesOrderHeaderResponseModel>> BySalesPersonID(int? salesPersonID, int limit = 0, int offset = int.MaxValue)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.BySalesPersonID(salesPersonID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderDetailResponseModel>> SalesOrderDetails(int salesOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderDetail> records = await this.SalesOrderHeaderRepository.SalesOrderDetails(salesOrderID, limit, offset);

			return this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiSalesOrderHeaderResponseModel>> BySalesOrderID(int salesOrderID, int limit = int.MaxValue, int offset = 0)
		{
			List<SalesOrderHeader> records = await this.SalesOrderHeaderRepository.BySalesOrderID(salesOrderID, limit, offset);

			return this.BolSalesOrderHeaderMapper.MapBOToModel(this.DalSalesOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>e706f49f17139963a4d7f11321a180af</Hash>
</Codenesium>*/