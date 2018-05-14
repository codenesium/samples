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
	public abstract class AbstractBOUnitMeasure
	{
		private IUnitMeasureRepository unitMeasureRepository;
		private IApiUnitMeasureModelValidator unitMeasureModelValidator;
		private ILogger logger;

		public AbstractBOUnitMeasure(
			ILogger logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureModelValidator unitMeasureModelValidator)

		{
			this.unitMeasureRepository = unitMeasureRepository;
			this.unitMeasureModelValidator = unitMeasureModelValidator;
			this.logger = logger;
		}

		public virtual List<POCOUnitMeasure> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.unitMeasureRepository.All(skip, take, orderClause);
		}

		public virtual POCOUnitMeasure Get(string unitMeasureCode)
		{
			return this.unitMeasureRepository.Get(unitMeasureCode);
		}

		public virtual async Task<CreateResponse<POCOUnitMeasure>> Create(
			ApiUnitMeasureModel model)
		{
			CreateResponse<POCOUnitMeasure> response = new CreateResponse<POCOUnitMeasure>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				POCOUnitMeasure record = this.unitMeasureRepository.Create(model);
				response.SetRecord(record);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string unitMeasureCode,
			ApiUnitMeasureModel model)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model));

			if (response.Success)
			{
				this.unitMeasureRepository.Update(unitMeasureCode, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));

			if (response.Success)
			{
				this.unitMeasureRepository.Delete(unitMeasureCode);
			}
			return response;
		}

		public POCOUnitMeasure GetName(string name)
		{
			return this.unitMeasureRepository.GetName(name);
		}
	}
}

/*<Codenesium>
    <Hash>0b5629ffe0dc6616e73556d082021670</Hash>
</Codenesium>*/