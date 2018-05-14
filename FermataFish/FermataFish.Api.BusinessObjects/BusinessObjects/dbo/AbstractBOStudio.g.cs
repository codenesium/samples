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
		private IApiStudioModelValidator studioModelValidator;
		private ILogger logger;

		public AbstractBOStudio(
			ILogger logger,
			IStudioRepository studioRepository,
			IApiStudioModelValidator studioModelValidator)

		{
			this.studioRepository = studioRepository;
			this.studioModelValidator = studioModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOStudio> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.studioRepository.All(skip, take, orderClause);
		}

		public virtual POCOStudio Get(int id)
		{
			return this.studioRepository.Get(id);
		}

		public virtual async Task<CreateResponse<POCOStudio>> Create(
			ApiStudioModel model)
		{
			CreateResponse<POCOStudio> response = new CreateResponse<POCOStudio>(await this.studioModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOStudio record = this.studioRepository.Create(model);
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
	}
}

/*<Codenesium>
    <Hash>74e385e303de34bef151dd3352fba91c</Hash>
</Codenesium>*/