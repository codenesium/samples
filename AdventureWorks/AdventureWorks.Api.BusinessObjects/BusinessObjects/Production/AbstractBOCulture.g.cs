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
	public abstract class AbstractBOCulture
	{
		private ICultureRepository cultureRepository;
		private ICultureModelValidator cultureModelValidator;
		private ILogger logger;

		public AbstractBOCulture(
			ILogger logger,
			ICultureRepository cultureRepository,
			ICultureModelValidator cultureModelValidator)

		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<string>> Create(
			CultureModel model)
		{
			CreateResponse<string> response = new CreateResponse<string>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				string id = this.cultureRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string cultureID,
			CultureModel model)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateUpdateAsync(cultureID, model));

			if (response.Success)
			{
				this.cultureRepository.Update(cultureID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateDeleteAsync(cultureID));

			if (response.Success)
			{
				this.cultureRepository.Delete(cultureID);
			}
			return response;
		}

		public virtual ApiResponse GetById(string cultureID)
		{
			return this.cultureRepository.GetById(cultureID);
		}

		public virtual POCOCulture GetByIdDirect(string cultureID)
		{
			return this.cultureRepository.GetByIdDirect(cultureID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.cultureRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.cultureRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCulture> GetWhereDirect(Expression<Func<EFCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.cultureRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>4a73a50754b22bb5800478bea341f472</Hash>
</Codenesium>*/