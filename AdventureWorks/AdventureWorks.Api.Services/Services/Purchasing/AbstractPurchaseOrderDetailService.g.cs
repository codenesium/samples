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
	public abstract class AbstractPurchaseOrderDetailService: AbstractService
	{
		private IPurchaseOrderDetailRepository purchaseOrderDetailRepository;
		private IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator;
		private IBOLPurchaseOrderDetailMapper BOLPurchaseOrderDetailMapper;
		private IDALPurchaseOrderDetailMapper DALPurchaseOrderDetailMapper;
		private ILogger logger;

		public AbstractPurchaseOrderDetailService(
			ILogger logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper bolpurchaseOrderDetailMapper,
			IDALPurchaseOrderDetailMapper dalpurchaseOrderDetailMapper)
			: base()

		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
			this.BOLPurchaseOrderDetailMapper = bolpurchaseOrderDetailMapper;
			this.DALPurchaseOrderDetailMapper = dalpurchaseOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.purchaseOrderDetailRepository.All(skip, take, orderClause);

			return this.BOLPurchaseOrderDetailMapper.MapBOToModel(this.DALPurchaseOrderDetailMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID)
		{
			var record = await purchaseOrderDetailRepository.Get(purchaseOrderID);

			return this.BOLPurchaseOrderDetailMapper.MapBOToModel(this.DALPurchaseOrderDetailMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
			ApiPurchaseOrderDetailRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderDetailResponseModel> response = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPurchaseOrderDetailMapper.MapModelToBO(default (int), model);
				var record = await this.purchaseOrderDetailRepository.Create(this.DALPurchaseOrderDetailMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPurchaseOrderDetailMapper.MapBOToModel(this.DALPurchaseOrderDetailMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			ApiPurchaseOrderDetailRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLPurchaseOrderDetailMapper.MapModelToBO(purchaseOrderID, model);
				await this.purchaseOrderDetailRepository.Update(this.DALPurchaseOrderDetailMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderDetailModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				await this.purchaseOrderDetailRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public async Task<List<ApiPurchaseOrderDetailResponseModel>> GetProductID(int productID)
		{
			List<PurchaseOrderDetail> records = await this.purchaseOrderDetailRepository.GetProductID(productID);

			return this.BOLPurchaseOrderDetailMapper.MapBOToModel(this.DALPurchaseOrderDetailMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>755c03636f3181e5c102f7084d716344</Hash>
</Codenesium>*/