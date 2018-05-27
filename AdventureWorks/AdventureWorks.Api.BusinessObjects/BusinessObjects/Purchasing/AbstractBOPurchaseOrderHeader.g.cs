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
	public abstract class AbstractBOPurchaseOrderHeader: AbstractBOManager
	{
		private IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository;
		private IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator;
		private IBOLPurchaseOrderHeaderMapper purchaseOrderHeaderMapper;
		private ILogger logger;

		public AbstractBOPurchaseOrderHeader(
			ILogger logger,
			IPurchaseOrderHeaderRepository purchaseOrderHeaderRepository,
			IApiPurchaseOrderHeaderRequestModelValidator purchaseOrderHeaderModelValidator,
			IBOLPurchaseOrderHeaderMapper purchaseOrderHeaderMapper)
			: base()

		{
			this.purchaseOrderHeaderRepository = purchaseOrderHeaderRepository;
			this.purchaseOrderHeaderModelValidator = purchaseOrderHeaderModelValidator;
			this.purchaseOrderHeaderMapper = purchaseOrderHeaderMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPurchaseOrderHeaderResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.purchaseOrderHeaderRepository.All(skip, take, orderClause);

			return this.purchaseOrderHeaderMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPurchaseOrderHeaderResponseModel> Get(int purchaseOrderID)
		{
			var record = await purchaseOrderHeaderRepository.Get(purchaseOrderID);

			return this.purchaseOrderHeaderMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPurchaseOrderHeaderResponseModel>> Create(
			ApiPurchaseOrderHeaderRequestModel model)
		{
			CreateResponse<ApiPurchaseOrderHeaderResponseModel> response = new CreateResponse<ApiPurchaseOrderHeaderResponseModel>(await this.purchaseOrderHeaderModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.purchaseOrderHeaderMapper.MapModelToDTO(default (int), model);
				var record = await this.purchaseOrderHeaderRepository.Create(dto);

				response.SetRecord(this.purchaseOrderHeaderMapper.MapDTOToModel(record));
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
				var dto = this.purchaseOrderHeaderMapper.MapModelToDTO(purchaseOrderID, model);
				await this.purchaseOrderHeaderRepository.Update(purchaseOrderID, dto);
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
			List<DTOPurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetEmployeeID(employeeID);

			return this.purchaseOrderHeaderMapper.MapDTOToModel(records);
		}
		public async Task<List<ApiPurchaseOrderHeaderResponseModel>> GetVendorID(int vendorID)
		{
			List<DTOPurchaseOrderHeader> records = await this.purchaseOrderHeaderRepository.GetVendorID(vendorID);

			return this.purchaseOrderHeaderMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>61f85ebee8680b292597068e20d0c6b7</Hash>
</Codenesium>*/