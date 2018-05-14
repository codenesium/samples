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
		private IApiCultureModelValidator cultureModelValidator;
		private ILogger logger;

		public AbstractBOCulture(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureModelValidator cultureModelValidator)

		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOCulture> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.cultureRepository.All(skip, take, orderClause);
		}

		public virtual POCOCulture Get(string cultureID)
		{
			return this.cultureRepository.Get(cultureID);
		}

		public virtual async Task<CreateResponse<POCOCulture>> Create(
			ApiCultureModel model)
		{
			CreateResponse<POCOCulture> response = new CreateResponse<POCOCulture>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCulture record = this.cultureRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string cultureID,
			ApiCultureModel model)
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

		public POCOCulture GetName(string name)
		{
			return this.cultureRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>1e246050c87ef4d6d0afdc7edb27be60</Hash>
</Codenesium>*/