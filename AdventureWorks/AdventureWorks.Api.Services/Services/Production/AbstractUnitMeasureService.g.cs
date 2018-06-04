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
		private IBOLUnitMeasureMapper BOLUnitMeasureMapper;
		private IDALUnitMeasureMapper DALUnitMeasureMapper;
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
			this.BOLUnitMeasureMapper = bolunitMeasureMapper;
			this.DALUnitMeasureMapper = dalunitMeasureMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUnitMeasureResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.unitMeasureRepository.All(skip, take, orderClause);

			return this.BOLUnitMeasureMapper.MapBOToModel(this.DALUnitMeasureMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUnitMeasureResponseModel> Get(string unitMeasureCode)
		{
			var record = await unitMeasureRepository.Get(unitMeasureCode);

			return this.BOLUnitMeasureMapper.MapBOToModel(this.DALUnitMeasureMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiUnitMeasureResponseModel>> Create(
			ApiUnitMeasureRequestModel model)
		{
			CreateResponse<ApiUnitMeasureResponseModel> response = new CreateResponse<ApiUnitMeasureResponseModel>(await this.unitMeasureModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLUnitMeasureMapper.MapModelToBO(default (string), model);
				var record = await this.unitMeasureRepository.Create(this.DALUnitMeasureMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLUnitMeasureMapper.MapBOToModel(this.DALUnitMeasureMapper.MapEFToBO(record)));
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
				var bo = this.BOLUnitMeasureMapper.MapModelToBO(unitMeasureCode, model);
				await this.unitMeasureRepository.Update(this.DALUnitMeasureMapper.MapBOToEF(bo));
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

			return this.BOLUnitMeasureMapper.MapBOToModel(this.DALUnitMeasureMapper.MapEFToBO(record));
		}
	}
}

/*<Codenesium>
    <Hash>bc7f21a39bd102b3ec0287e850b5de5c</Hash>
</Codenesium>*/