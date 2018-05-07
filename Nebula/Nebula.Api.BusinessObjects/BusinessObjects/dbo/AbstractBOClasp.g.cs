using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
{
	public abstract class AbstractBOClasp
	{
		private IClaspRepository claspRepository;
		private IClaspModelValidator claspModelValidator;
		private ILogger logger;

		public AbstractBOClasp(
			ILogger logger,
			IClaspRepository claspRepository,
			IClaspModelValidator claspModelValidator)

		{
			this.claspRepository = claspRepository;
			this.claspModelValidator = claspModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			ClaspModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.claspModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.claspRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int id,
			ClaspModel model)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateUpdateAsync(id, model));

			if (response.Success)
			{
				this.claspRepository.Update(id, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.claspModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				this.claspRepository.Delete(id);
			}
			return response;
		}

		public virtual POCOClasp Get(int id)
		{
			return this.claspRepository.Get(id);
		}

		public virtual List<POCOClasp> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.claspRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>0afa214bd60a3de6a79d268d49bfd29d</Hash>
</Codenesium>*/