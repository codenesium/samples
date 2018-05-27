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
	public abstract class AbstractBOPurchaseOrderDetail: AbstractBOManager
	{
		private IPurchaseOrderDetailRepository purchaseOrderDetailRepository;
		private IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator;
		private IBOLPurchaseOrderDetailMapper purchaseOrderDetailMapper;
		private ILogger logger;

		public AbstractBOPurchaseOrderDetail(
			ILogger logger,
			IPurchaseOrderDetailRepository purchaseOrderDetailRepository,
			IApiPurchaseOrderDetailRequestModelValidator purchaseOrderDetailModelValidator,
			IBOLPurchaseOrderDetailMapper purchaseOrderDetailMapper)
			: base()

		{
			this.purchaseOrderDetailRepository = purchaseOrderDetailRepository;
			this.purchaseOrderDetailModelValidator = purchaseOrderDetailModelValidator;
			this.purchaseOrderDetailMapper = purchaseOrderDetailMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderDetailResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.purchaseOrderDetailRepository.All(skip, take, orderClause);

			return this.purchaseOrderDetailMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPurchaseOrderDetailResponseModel> Get(int purchaseOrderID)
		{
			var record = await purchaseOrderDetailRepository.Get(purchaseOrderID);

			return this.purchaseOrderDetailMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderDetailResponseModel>> Create(
			ApiPurchaseOrderDetailRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderDetailResponseModel> response = new CreateResponse<ApiPurchaseOrderDetailResponseModel>(await this.purchaseOrderDetailModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.purchaseOrderDetailMapper.MapModelToDTO(default (int), model);
				var record = await this.purchaseOrderDetailRepository.Create(dto);

				response.SetRecord(this.purchaseOrderDetailMapper.MapDTOToModel(record));
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
				var dto = this.purchaseOrderDetailMapper.MapModelToDTO(purchaseOrderID, model);
				await this.purchaseOrderDetailRepository.Update(purchaseOrderID, dto);
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
			List<DTOPurchaseOrderDetail> records = await this.purchaseOrderDetailRepository.GetProductID(productID);

			return this.purchaseOrderDetailMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>0b67cc25648904137a5532a029ed73cd</Hash>
</Codenesium>*/