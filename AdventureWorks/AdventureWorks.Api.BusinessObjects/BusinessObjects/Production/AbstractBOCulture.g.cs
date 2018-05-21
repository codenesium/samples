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
	public abstract class AbstractBOCulture: AbstractBOManager
	{
		private ICultureRepository cultureRepository;
		private IApiCultureModelValidator cultureModelValidator;
		private ILogger logger;

		public AbstractBOCulture(
			ILogger logger,
			ICultureRepository cultureRepository,
			IApiCultureModelValidator cultureModelValidator)
			: base()

		{
			this.cultureRepository = cultureRepository;
			this.cultureModelValidator = cultureModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.cultureRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOCulture> Get(string cultureID)
		{
			return this.cultureRepository.Get(cultureID);
		}

		public virtual async Task<CreateResponse<POCOCulture>> Create(
			ApiCultureModel model)
		{
			CreateResponse<POCOCulture> response = new CreateResponse<POCOCulture>(await this.cultureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOCulture record = await this.cultureRepository.Create(model);

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
				await this.cultureRepository.Update(cultureID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string cultureID)
		{
			ActionResponse response = new ActionResponse(await this.cultureModelValidator.ValidateDeleteAsync(cultureID));

			if (response.Success)
			{
				await this.cultureRepository.Delete(cultureID);
			}
			return response;
		}

		public async Task<POCOCulture> GetName(string name)
		{
			return await this.cultureRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>21e92e4397d9438853377a06e453a891</Hash>
</Codenesium>*/