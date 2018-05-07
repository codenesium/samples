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
	public abstract class AbstractBOStudio
	{
		private IStudioRepository studioRepository;
		private IStudioModelValidator studioModelValidator;
		private ILogger logger;

		public AbstractBOStudio(
			ILogger logger,
			IStudioRepository studioRepository,
			IStudioModelValidator studioModelValidator)

		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StudioModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.studioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.studioRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			StudioModel model)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.studioRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.studioModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.studioRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOStudio Get(int id)
		{
			return this.studioRepository.Get(id);
		}

		public virtual List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studioRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>c87b62c0268a9d802d40adca009c5bec</Hash>
</Codenesium>*/