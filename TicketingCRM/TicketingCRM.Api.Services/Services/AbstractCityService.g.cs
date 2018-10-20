using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractCityService : AbstractService
	{
		protected ICityRepository CityRepository { get; private set; }

		protected IApiCityRequestModelValidator CityModelValidator { get; private set; }

		protected IBOLCityMapper BolCityMapper { get; private set; }

		protected IDALCityMapper DalCityMapper { get; private set; }

		protected IBOLEventMapper BolEventMapper { get; private set; }

		protected IDALEventMapper DalEventMapper { get; private set; }

		private ILogger logger;

		public AbstractCityService(
			ILogger logger,
			ICityRepository cityRepository,
			IApiCityRequestModelValidator cityModelValidator,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLEventMapper bolEventMapper,
			IDALEventMapper dalEventMapper)
			: base()
		{
			this.CityRepository = cityRepository;
			this.CityModelValidator = cityModelValidator;
			this.BolCityMapper = bolCityMapper;
			this.DalCityMapper = dalCityMapper;
			this.BolEventMapper = bolEventMapper;
			this.DalEventMapper = dalEventMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiCityResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.CityRepository.All(limit, offset);

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiCityResponseModel> Get(int id)
		{
			var record = await this.CityRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiCityResponseModel>> Create(
			ApiCityRequestModel model)
		{
			CreateResponse<ApiCityResponseModel> response = new CreateResponse<ApiCityResponseModel>(await this.CityModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolCityMapper.MapModelToBO(default(int), model);
				var record = await this.CityRepository.Create(this.DalCityMapper.MapBOToEF(bo));

				response.SetRecord(this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiCityResponseModel>> Update(
			int id,
			ApiCityRequestModel model)
		{
			var validationResult = await this.CityModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolCityMapper.MapModelToBO(id, model);
				await this.CityRepository.Update(this.DalCityMapper.MapBOToEF(bo));

				var record = await this.CityRepository.Get(id);

				return new UpdateResponse<ApiCityResponseModel>(this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiCityResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.CityModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.CityRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiCityResponseModel>> ByProvinceId(int provinceId, int limit = 0, int offset = int.MaxValue)
		{
			List<City> records = await this.CityRepository.ByProvinceId(provinceId, limit, offset);

			return this.BolCityMapper.MapBOToModel(this.DalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiEventResponseModel>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0)
		{
			List<Event> records = await this.CityRepository.EventsByCityId(cityId, limit, offset);

			return this.BolEventMapper.MapBOToModel(this.DalEventMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>0c0fa697a1fdd5956e0af2fb4b44e5e5</Hash>
</Codenesium>*/