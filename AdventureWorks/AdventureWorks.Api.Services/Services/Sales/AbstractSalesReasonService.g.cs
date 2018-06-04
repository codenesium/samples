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
	public abstract class AbstractSalesReasonService: AbstractService
	{
		private ISalesReasonRepository salesReasonRepository;
		private IApiSalesReasonRequestModelValidator salesReasonModelValidator;
		private IBOLSalesReasonMapper BOLSalesReasonMapper;
		private IDALSalesReasonMapper DALSalesReasonMapper;
		private ILogger logger;

		public AbstractSalesReasonService(
			ILogger logger,
			ISalesReasonRepository salesReasonRepository,
			IApiSalesReasonRequestModelValidator salesReasonModelValidator,
			IBOLSalesReasonMapper bolsalesReasonMapper,
			IDALSalesReasonMapper dalsalesReasonMapper)
			: base()

		{
			this.salesReasonRepository = salesReasonRepository;
			this.salesReasonModelValidator = salesReasonModelValidator;
			this.BOLSalesReasonMapper = bolsalesReasonMapper;
			this.DALSalesReasonMapper = dalsalesReasonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesReasonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesReasonRepository.All(skip, take, orderClause);

			return this.BOLSalesReasonMapper.MapBOToModel(this.DALSalesReasonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesReasonResponseModel> Get(int salesReasonID)
		{
			var record = await salesReasonRepository.Get(salesReasonID);

			return this.BOLSalesReasonMapper.MapBOToModel(this.DALSalesReasonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesReasonResponseModel>> Create(
			ApiSalesReasonRequestModel model)
		{
			CreateResponse<ApiSalesReasonResponseModel> response = new CreateResponse<ApiSalesReasonResponseModel>(await this.salesReasonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesReasonMapper.MapModelToBO(default (int), model);
				var record = await this.salesReasonRepository.Create(this.DALSalesReasonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesReasonMapper.MapBOToModel(this.DALSalesReasonMapper.MapEFToBO(record)));
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
				var bo = this.BOLSalesReasonMapper.MapModelToBO(salesReasonID, model);
				await this.salesReasonRepository.Update(this.DALSalesReasonMapper.MapBOToEF(bo));
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
    <Hash>20706e728172cd66e4b99ab260a65d89</Hash>
</Codenesium>*/