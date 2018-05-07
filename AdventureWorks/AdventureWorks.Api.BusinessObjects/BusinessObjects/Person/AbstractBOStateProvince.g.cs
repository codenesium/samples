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
	public abstract class AbstractBOStateProvince
	{
		private IStateProvinceRepository stateProvinceRepository;
		private IStateProvinceModelValidator stateProvinceModelValidator;
		private ILogger logger;

		public AbstractBOStateProvince(
			ILogger logger,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator)

		{
			this.stateProvinceRepository = stateProvinceRepository;
			this.stateProvinceModelValidator = stateProvinceModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			StateProvinceModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.stateProvinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.stateProvinceRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int stateProvinceID,
			StateProvinceModel model)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateUpdateAsync(stateProvinceID, model));

			if (response.Success)
			{
				this.stateProvinceRepository.Update(stateProvinceID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int stateProvinceID)
		{
			ActionResponse response = new ActionResponse(await this.stateProvinceModelValidator.ValidateDeleteAsync(stateProvinceID));

			if (response.Success)
			{
				this.stateProvinceRepository.Delete(stateProvinceID);
			}
			return response;
		}

		public virtual POCOStateProvince Get(int stateProvinceID)
		{
			return this.stateProvinceRepository.Get(stateProvinceID);
		}

		public virtual List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.stateProvinceRepository.All(skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>3f6f282a0222a2533732bc207284f071</Hash>
</Codenesium>*/