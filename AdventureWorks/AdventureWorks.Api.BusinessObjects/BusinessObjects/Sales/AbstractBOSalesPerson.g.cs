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
	public abstract class AbstractBOSalesPerson: AbstractBOManager
	{
		private ISalesPersonRepository salesPersonRepository;
		private IApiSalesPersonRequestModelValidator salesPersonModelValidator;
		private IBOLSalesPersonMapper salesPersonMapper;
		private ILogger logger;

		public AbstractBOSalesPerson(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonRequestModelValidator salesPersonModelValidator,
			IBOLSalesPersonMapper salesPersonMapper)
			: base()

		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
			this.salesPersonMapper = salesPersonMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiSalesPersonResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.salesPersonRepository.All(skip, take, orderClause);

			return this.salesPersonMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiSalesPersonResponseModel> Get(int businessEntityID)
		{
			var record = await salesPersonRepository.Get(businessEntityID);

			return this.salesPersonMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiSalesPersonResponseModel>> Create(
			ApiSalesPersonRequestModel model)
		{
			CreateResponse<ApiSalesPersonResponseModel> response = new CreateResponse<ApiSalesPersonResponseModel>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.salesPersonMapper.MapModelToDTO(default (int), model);
				var record = await this.salesPersonRepository.Create(dto);

				response.SetRecord(this.salesPersonMapper.MapDTOToModel(record));
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
				var dto = this.salesPersonMapper.MapModelToDTO(businessEntityID, model);
				await this.salesPersonRepository.Update(businessEntityID, dto);
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
    <Hash>f852d579a33f3a71a96b25a31600c2d1</Hash>
</Codenesium>*/