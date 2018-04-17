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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			return this.salesPersonRepository.GetById(businessEntityID);
		}

		public virtual POCOSalesPerson GetByIdDirect(int businessEntityID)
		{
			return this.salesPersonRepository.GetByIdDirect(businessEntityID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesPerson> GetWhereDirect(Expression<Func<EFSalesPerson, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.salesPersonRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>33c0a63a37be0773a860eab96ac7bed3</Hash>
</Codenesium>*/