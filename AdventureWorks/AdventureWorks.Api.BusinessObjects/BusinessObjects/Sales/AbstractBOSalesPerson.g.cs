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
	public abstract class AbstractBOSalesPerson
	{
		private ISalesPersonRepository salesPersonRepository;
		private IApiSalesPersonModelValidator salesPersonModelValidator;
		private ILogger logger;

		public AbstractBOSalesPerson(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			IApiSalesPersonModelValidator salesPersonModelValidator)

		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.All(skip, take, orderClause);
		}

		public virtual POCOSalesPerson Get(int businessEntityID)
		{
			return this.salesPersonRepository.Get(businessEntityID);
		}

		public virtual async Task<CreateResponse<POCOSalesPerson>> Create(
			ApiSalesPersonModel model)
		{
			CreateResponse<POCOSalesPerson> response = new CreateResponse<POCOSalesPerson>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOSalesPerson record = this.salesPersonRepository.Create(model);
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
				this.salesPersonRepository.Update(businessEntityID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.salesPersonModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				this.salesPersonRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>ae239263254df8ac958bf2f63ac5700a</Hash>
</Codenesium>*/