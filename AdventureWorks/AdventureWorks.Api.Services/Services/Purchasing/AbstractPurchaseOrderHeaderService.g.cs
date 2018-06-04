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
	public abstract class AbstractPurchaseOrderHeaderService: AbstractService
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		private IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator;
		private IBOLPurchaseOrderHeaderMapper BOLPurchaseOrderHeaderMapper;
		private IDALPurchaseOrderHeaderMapper DALPurchaseOrderHeaderMapper;
		private ILogger logger;

		public AbstractPurchaseOrderHeaderService(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper bolpurchaseOrderHeaderMapper,
			IDALPurchaseOrderHeaderMapper dalpurchaseOrderHeaderMapper)
			: base()

		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.BOLPurchaseOrderHeaderMapper = bolpurchaseOrderHeaderMapper;
			this.DALPurchaseOrderHeaderMapper = dalpurchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.purchaseOrderHeaderRepository.All(skip, take, orderClause);

			return this.BOLPurchaseOrderHeaderMapper.MapBOToModel(this.DALPurchaseOrderHeaderMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID)
		{
			var record = await purchaseOrderHeaderRepository.Get(purchaseOrderID);

			return this.BOLPurchaseOrderHeaderMapper.MapBOToModel(this.DALPurchaseOrderHeaderMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPurchaseOrderHeaderMapper.MapModelToBO(default (int), model);
				var record = await this.purchaseOrderHeaderRepository.Create(this.DALPurchaseOrderHeaderMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPurchaseOrderHeaderMapper.MapBOToModel(this.DALPurchaseOrderHeaderMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int purchaseOrderID,
			ApiPurchaseOrderHeaderRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateUpdateAsync(purchaseOrderID, model));

			if (response.Success)
			{
				var bo = this.BOLPurchaseOrderHeaderMapper.MapModelToBO(purchaseOrderID, model);
				await this.purchaseOrderHeaderRepository.Update(this.DALPurchaseOrderHeaderMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int purchaseOrderID)
		{
			ActionResponse response = new ActionResponse(await this.purchaseOrderHeaderModelValidator.ValidateDeleteAsync(purchaseOrderID));

			if (response.Success)
			{
				await this.purchaseOrderHeaderRepository.Delete(purchaseOrderID);
			}
			return response;
		}

		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetEmployeeID(int employeeID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetEmployeeID(employeeID);

			return this.BOLPurchaseOrderHeaderMapper.MapBOToModel(this.DALPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetVendorID(int vendorID)
		{
			List<PurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetVendorID(vendorID);

			return this.BOLPurchaseOrderHeaderMapper.MapBOToModel(this.DALPurchaseOrderHeaderMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>491b650b840a7820255e96fbf62bc323</Hash>
</Codenesium>*/