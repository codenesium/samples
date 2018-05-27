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
	public abstract class AbstractBOSalesOrderHeaderSalesReason: AbstractBOManager
	{
		private ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository;
		private IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator;
		private IBOLSalesOrderHeaderSalesReasonMapper salesOrderHeaderSalesReasonMapper;
		private ILogger logger;

		public AbstractBOSalesOrderHeaderSalesReason(
			ILogger logger,
			ISalesOrderHeaderSalesReasonRepository salesOrderHeaderSalesReasonRepository,
			IApiSalesOrderHeaderSalesReasonRequestModelValidator salesOrderHeaderSalesReasonModelValidator,
			IBOLSalesOrderHeaderSalesReasonMapper salesOrderHeaderSalesReasonMapper)
			: base()

		{
			this.salesOrderHeaderSalesReasonRepository = salesOrderHeaderSalesReasonRepository;
			this.salesOrderHeaderSalesReasonModelValidator = salesOrderHeaderSalesReasonModelValidator;
			this.salesOrderHeaderSalesReasonMapper = salesOrderHeaderSalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesOrderHeaderSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesOrderHeaderSalesReasonRepository.All(skip, take, orderClause);

			return this.salesOrderHeaderSalesReasonMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesOrderHeaderSalesReasonResponseModel> Get(int salesOrderID)
		{
			var record = await salesOrderHeaderSalesReasonRepository.Get(salesOrderID);

			return this.salesOrderHeaderSalesReasonMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>> Create(
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel> response = new CreateResponse<ApiSalesOrderHeaderSalesReasonResponseModel>(await this.salesOrderHeaderSalesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesOrderHeaderSalesReasonMapper.MapModelToDTO(default (int), model);
				var record = await this.salesOrderHeaderSalesReasonRepository.Create(dto);

				response.SetRecord(this.salesOrderHeaderSalesReasonMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesOrderID,
			ApiSalesOrderHeaderSalesReasonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateUpdateAsync(salesOrderID, model));

			if (response.Success)
			{
				var dto = this.salesOrderHeaderSalesReasonMapper.MapModelToDTO(salesOrderID, model);
				await this.salesOrderHeaderSalesReasonRepository.Update(salesOrderID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesOrderID)
		{
			ActionResponse response = new ActionResponse(await this.salesOrderHeaderSalesReasonModelValidator.ValidateDeleteAsync(salesOrderID));

			if (response.Success)
			{
				await this.salesOrderHeaderSalesReasonRepository.Delete(salesOrderID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9ecdcb5e7add6a57ef102ec301cc9a43</Hash>
</Codenesium>*/