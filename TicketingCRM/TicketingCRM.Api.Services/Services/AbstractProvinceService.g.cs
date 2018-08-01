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
	public abstract class AbstractProvinceService : AbstractService
	{
		private IProvinceRepository provinceRepository;

		private IApiProvinceRequestModelValidator provinceModelValidator;

		private IBOLProvinceMapper bolProvinceMapper;

		private IDALProvinceMapper dalProvinceMapper;

		private IBOLCityMapper bolCityMapper;

		private IDALCityMapper dalCityMapper;
		private IBOLVenueMapper bolVenueMapper;

		private IDALVenueMapper dalVenueMapper;

		private ILogger logger;

		public AbstractProvinceService(
			ILogger logger,
			IProvinceRepository provinceRepository,
			IApiProvinceRequestModelValidator provinceModelValidator,
			IBOLProvinceMapper bolProvinceMapper,
			IDALProvinceMapper dalProvinceMapper,
			IBOLCityMapper bolCityMapper,
			IDALCityMapper dalCityMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.provinceRepository = provinceRepository;
			this.provinceModelValidator = provinceModelValidator;
			this.bolProvinceMapper = bolProvinceMapper;
			this.dalProvinceMapper = dalProvinceMapper;
			this.bolCityMapper = bolCityMapper;
			this.dalCityMapper = dalCityMapper;
			this.bolVenueMapper = bolVenueMapper;
			this.dalVenueMapper = dalVenueMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiProvinceResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.provinceRepository.All(limit, offset);

			return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiProvinceResponseModel> Get(int id)
		{
			var record = await this.provinceRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiProvinceResponseModel>> Create(
			ApiProvinceRequestModel model)
		{
			CreateResponse<ApiProvinceResponseModel> response = new CreateResponse<ApiProvinceResponseModel>(await this.provinceModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolProvinceMapper.MapModelToBO(default(int), model);
				var record = await this.provinceRepository.Create(this.dalProvinceMapper.MapBOToEF(bo));

				response.SetRecord(this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiProvinceResponseModel>> Update(
			int id,
			ApiProvinceRequestModel model)
		{
			var validationResult = await this.provinceModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolProvinceMapper.MapModelToBO(id, model);
				await this.provinceRepository.Update(this.dalProvinceMapper.MapBOToEF(bo));

				var record = await this.provinceRepository.Get(id);

				return new UpdateResponse<ApiProvinceResponseModel>(this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiProvinceResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.provinceModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.provinceRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiProvinceResponseModel>> ByCountryId(int countryId)
		{
			List<Province> records = await this.provinceRepository.ByCountryId(countryId);

			return this.bolProvinceMapper.MapBOToModel(this.dalProvinceMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiCityResponseModel>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<City> records = await this.provinceRepository.Cities(provinceId, limit, offset);

			return this.bolCityMapper.MapBOToModel(this.dalCityMapper.MapEFToBO(records));
		}

		public async virtual Task<List<ApiVenueResponseModel>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.provinceRepository.Venues(provinceId, limit, offset);

			return this.bolVenueMapper.MapBOToModel(this.dalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>78a67fcb80ad3cd433c2ba454890566f</Hash>
</Codenesium>*/