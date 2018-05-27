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
	public abstract class AbstractBOSalesReason: AbstractBOManager
	{
		private ISalesReasonRepository salesReasonRepository;
		private IApiSalesReasonRequestModelValidator salesReasonModelValidator;
		private IBOLSalesReasonMapper salesReasonMapper;
		private ILogger logger;

		public AbstractBOSalesReason(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper salesReasonMapper)
			: base()

		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
			this.salesReasonMapper = salesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesReasonRepository.All(skip, take, orderClause);

			return this.salesReasonMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesReasonResponseModel> Get(int salesReasonID)
		{
			var record = await salesReasonRepository.Get(salesReasonID);

			return this.salesReasonMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
			ApiSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesReasonResponseModel> response = new CreateResponse<ApiSalesReasonResponseModel>(await this.salesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesReasonMapper.MapModelToDTO(default (int), model);
				var record = await this.salesReasonRepository.Create(dto);

				response.SetRecord(this.salesReasonMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int salesReasonID,
			ApiSalesReasonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateUpdateAsync(salesReasonID, model));

			if (response.Success)
			{
				var dto = this.salesReasonMapper.MapModelToDTO(salesReasonID, model);
				await this.salesReasonRepository.Update(salesReasonID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int salesReasonID)
		{
			ActionResponse response = new ActionResponse(await this.salesReasonModelValidator.ValidateDeleteAsync(salesReasonID));

			if (response.Success)
			{
				await this.salesReasonRepository.Delete(salesReasonID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>76258c7f7515897bed8782fa18f48802</Hash>
</Codenesium>*/