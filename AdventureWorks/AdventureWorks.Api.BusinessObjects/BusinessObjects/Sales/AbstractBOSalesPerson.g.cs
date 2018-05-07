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
		private ISalesPersonModelValidator salesPersonModelValidator;
		private ILogger logger;

		public AbstractBOSalesPerson(
			ILogger logger,
			ISalesPersonRepository salesPersonRepository,
			ISalesPersonModelValidator salesPersonModelValidator)

		{
			this.salesPersonRepository = salesPersonRepository;
			this.salesPersonModelValidator = salesPersonModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			SalesPersonModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.salesPersonModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.salesPersonRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			SalesPersonModel model)
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

		public virtual POCOSalesPerson Get(int businessEntityID)
		{
			return this.salesPersonRepository.Get(businessEntityID);
		}

		public virtual List<POCOSalesPerson> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>716b76bedd895b569f3f2a6813c2d3a3</Hash>
</Codenesium>*/