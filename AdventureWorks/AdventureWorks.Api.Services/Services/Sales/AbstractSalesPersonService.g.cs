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
	public abstract class AbstractSalesPersonService: AbstractService
	{
		private ISalesPersonRepository salesPersonRepository;
		private IApiSalesPersonRequestModelValidator salesPersonModelValidator;
		private IBOLSalesPersonMapper BOLSalesPersonMapper;
		private IDALSalesPersonMapper DALSalesPersonMapper;
		private ILogger logger;

		public AbstractSalesPersonService(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper bolsalesPersonMapper,
			IDALSalesPersonMapper dalsalesPersonMapper)
			: base()

		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
			this.BOLSalesPersonMapper = bolsalesPersonMapper;
			this.DALSalesPersonMapper = dalsalesPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesPersonRepository.All(skip, take, orderClause);

			return this.BOLSalesPersonMapper.MapBOToModel(this.DALSalesPersonMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiSalesPersonResponseModel> Get(int businessEntityID)
		{
			var record = await salesPersonRepository.Get(businessEntityID);

			return this.BOLSalesPersonMapper.MapBOToModel(this.DALSalesPersonMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
			ApiSalesPersonRequestModel model)
		{
			CreateResponse<ApiSalesPersonResponseModel> response = new CreateResponse<ApiSalesPersonResponseModel>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLSalesPersonMapper.MapModelToBO(default (int), model);
				var record = await this.salesPersonRepository.Create(this.DALSalesPersonMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLSalesPersonMapper.MapBOToModel(this.DALSalesPersonMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesPersonRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLSalesPersonMapper.MapModelToBO(businessEntityID, model);
				await this.salesPersonRepository.Update(this.DALSalesPersonMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.salesPersonRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>0d2c4b402e0206cd82eeb6bc300229c9</Hash>
</Codenesium>*/