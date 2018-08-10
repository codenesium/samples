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
	public abstract class AbstractSalesOrderDetailService : AbstractService
	{
		protected ISalesOrderDetailRepository SalesOrderDetailRepository { get; private set; }

		protected IApiSalesOrderDetailRequestModelValidator SalesOrderDetailModelValidator { get; private set; }

		protected IBOLSalesOrderDetailMapper BolSalesOrderDetailMapper { get; private set; }

		protected IDALSalesOrderDetailMapper DalSalesOrderDetailMapper { get; private set; }

		private ILogger logger;

		public AbstractSalesOrderDetailService(
			ILogger logger,
			ISalesOrderDetailRepository salesOrderDetailRepository,
			IApiSalesOrderDetailRequestModelValidator salesOrderDetailModelValidator,
			IBOLSalesOrderDetailMapper bolSalesOrderDetailMapper,
			IDALSalesOrderDetailMapper dalSalesOrderDetailMapper)
			: base()
		{
			this.SalesOrderDetailRepository = salesOrderDetailRepository;
			this.SalesOrderDetailModelValidator = salesOrderDetailModelValidator;
			this.BolSalesOrderDetailMapper = bolSalesOrderDetailMapper;
			this.DalSalesOrderDetailMapper = dalSalesOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderDetailResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.SalesOrderDetailRepository.All(limit, offset);

			return this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesOrderDetailResponseModel> Get(int salesOrderID)
		{
			var record = await this.SalesOrderDetailRepository.Get(salesOrderID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiSalesOrderDetailResponseModel>> Create(
			ApiSalesOrderDetailRequestModel model)
		{
			CreateResponse<ApiSalesOrderDetailResponseModel> response = new CreateResponse<ApiSalesOrderDetailResponseModel>(await this.SalesOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolSalesOrderDetailMapper.MapModelToBO(default(int), model);
				var record = await this.SalesOrderDetailRepository.Create(this.DalSalesOrderDetailMapper.MapBOToEF(bo));

				response.SetRecord(this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiSalesOrderDetailResponseModel>> Update(
			int salesOrderID,
			ApiSalesOrderDetailRequestModel model)
		{
			var validationResult = await this.SalesOrderDetailModelValidator.ValidateUpdateAsync(salesOrderID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolSalesOrderDetailMapper.MapModelToBO(salesOrderID, model);
				await this.SalesOrderDetailRepository.Update(this.DalSalesOrderDetailMapper.MapBOToEF(bo));

				var record = await this.SalesOrderDetailRepository.Get(salesOrderID);

				return new UpdateResponse<ApiSalesOrderDetailResponseModel>(this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiSalesOrderDetailResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.SalesOrderDetailModelValidator.ValidateDeleteAsync(salesOrderID));
			if (response.Success)
			{
				await this.SalesOrderDetailRepository.Delete(salesOrderID);
			}

			return response;
		}

		public async Task<List<ApiSalesOrderDetailResponseModel>> ByProductID(int productID)
		{
			List<SalesOrderDetail> records = await this.SalesOrderDetailRepository.ByProductID(productID);

			return this.BolSalesOrderDetailMapper.MapBOToModel(this.DalSalesOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>b6741bc8f7ce7572e128c9654d823f39</Hash>
</Codenesium>*/