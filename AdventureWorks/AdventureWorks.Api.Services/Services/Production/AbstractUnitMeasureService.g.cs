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

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractUnitMeasureService: AbstractService
	{
		private IUnitMeasureRepository unitMeasureRepository;
		private IApiUnitMeasureRequestModelValidator unitMeasureModelValidator;
		private IBOLUnitMeasureMapper bolUnitMeasureMapper;
		private IDALUnitMeasureMapper dalUnitMeasureMapper;
		private ILogger logger;

		public AbstractUnitMeasureService(
			ILogger logger,
			IUnitMeasureRepository unitMeasureRepository,
			IApiUnitMeasureRequestModelValidator unitMeasureModelValidator,
			IBOLUnitMeasureMapper bolunitMeasureMapper,
			IDALUnitMeasureMapper dalunitMeasureMapper)
			: base()

		{
			this.unitMeasureRepository = unitMeasureRepository;
			this.unitMeasureModelValidator = unitMeasureModelValidator;
			this.bolUnitMeasureMapper = bolunitMeasureMapper;
			this.dalUnitMeasureMapper = dalunitMeasureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.unitMeasureRepository.All(skip, take, orderClause);

			return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode)
		{
			var record = await unitMeasureRepository.Get(unitMeasureCode);

			return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model)
		{
			CreateResponse<ApiUnitMeasureResponseModel> response = new CreateResponse<ApiUnitMeasureResponseModel>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolUnitMeasureMapper.MapModelToBO(default (string), model);
				var record = await this.unitMeasureRepository.Create(this.dalUnitMeasureMapper.MapBOToEF(bo));

				response.SetRecord(this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			string unitMeasureCode,
			ApiUnitMeasureRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateUpdateAsync(unitMeasureCode, model));

			if (response.Success)
			{
				var bo = this.bolUnitMeasureMapper.MapModelToBO(unitMeasureCode, model);
				await this.unitMeasureRepository.Update(this.dalUnitMeasureMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			string unitMeasureCode)
		{
			ActionResponse response = new ActionResponse(await this.unitMeasureModelValidator.ValidateDeleteAsync(unitMeasureCode));

			if (response.Success)
			{
				await this.unitMeasureRepository.Delete(unitMeasureCode);
			}
			return response;
		}

		public async Task<ApiUnitMeasureResponseModel> GetName(string name)
		{
			UnitMeasure record = await this.unitMeasureRepository.GetName(name);

			return this.bolUnitMeasureMapper.MapBOToModel(this.dalUnitMeasureMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>3bce85db791dd979165f56eada990e99</Hash>
</Codenesium>*/