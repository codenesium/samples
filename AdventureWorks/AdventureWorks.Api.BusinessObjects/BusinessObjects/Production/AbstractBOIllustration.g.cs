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
	public abstract class AbstractBOIllustration
	{
		private IIllustrationRepository illustrationRepository;
		private IIllustrationModelValidator illustrationModelValidator;
		private ILogger logger;

		public AbstractBOIllustration(
			ILogger logger,
			IIllustrationRepository illustrationRepository,
			IIllustrationModelValidator illustrationModelValidator)

		{
			this.illustrationRepository = illustrationRepository;
			this.illustrationModelValidator = illustrationModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			IllustrationModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.illustrationModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.illustrationRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int illustrationID,
			IllustrationModel model)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateUpdateAsync(illustrationID, model));

			if (response.Success)
			{
				this.illustrationRepository.Update(illustrationID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int illustrationID)
		{
			ActionResponse response = new ActionResponse(await this.illustrationModelValidator.ValidateDeleteAsync(illustrationID));

			if (response.Success)
			{
				this.illustrationRepository.Delete(illustrationID);
			}
			return response;
		}

		public virtual POCOIllustration Get(int illustrationID)
		{
			return this.illustrationRepository.Get(illustrationID);
		}

		public virtual List<POCOIllustration> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.illustrationRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>dd7a25da7ba06bc03463273a11535b28</Hash>
</Codenesium>*/