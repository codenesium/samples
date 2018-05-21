using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public abstract class AbstractBOStudio: AbstractBOManager
	{
		private IStudioRepository studioRepository;
		private IApiStudioModelValidator studioModelValidator;
		private ILogger logger;

		public AbstractBOStudio(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioModelValidator studioModelValidator)
			: base()

		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
			this.logger = logger;
		}

		public virtual Task<List<POCOStudio>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studioRepository.All(skip, take, orderClause);
		}

		public virtual Task<POCOStudio> Get(int id)
		{
			return this.studioRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOStudio>> Create(
			ApiStudioModel model)
		{
			CreateResponse<POCOStudio> response = new CreateResponse<POCOStudio>(await this.studioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStudio record = await this.studioRepository.Create(model);

				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ApiStudioModel model)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				await this.studioRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.studioRepository.Delete(id);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2b6614c3580fc083b87ebc1c12bac2e5</Hash>
</Codenesium>*/