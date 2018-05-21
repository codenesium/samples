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
		private IApiSalesPersonModelValidator salesPersonModelValidator;
		private ILogger logger;

		public AbstractBOSalesPerson(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonModelValidator salesPersonModelValidator)
			: base()

		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOSalesPerson>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOSalesPerson> Get(int businessEntityID)
		{
			return this.salesPersonRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOSalesPerson>> Create(
			ApiSalesPersonModel model)
		{
			CreateResponse<POCOSalesPerson> response = new CreateResponse<POCOSalesPerson>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesPerson record = await this.salesPersonRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiSalesPersonModel model)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				await this.salesPersonRepository.Update(businessEntityID, model);
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
    <Hash>f2dcfec01ddc52fc22b7f2a7e222c40d</Hash>
</Codenesium>*/