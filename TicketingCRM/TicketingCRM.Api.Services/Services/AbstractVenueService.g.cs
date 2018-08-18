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
	public abstract class AbstractVenueService : AbstractService
	{
		protected IVenueRepository VenueRepository { get; private set; }

		protected IApiVenueRequestModelValidator VenueModelValidator { get; private set; }

		protected IBOLVenueMapper BolVenueMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractVenueService(
			ILogger logger,
			IVenueRepository venueRepository,
			IApiVenueRequestModelValidator venueModelValidator,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.VenueRepository = venueRepository;
			this.VenueModelValidator = venueModelValidator;
			this.BolVenueMapper = bolVenueMapper;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiVenueResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.VenueRepository.All(limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiVenueResponseModel> Get(int id)
		{
			var record = await this.VenueRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiVenueResponseModel>> Create(
			ApiVenueRequestModel model)
		{
			CreateResponse<ApiVenueResponseModel> response = new CreateResponse<ApiVenueResponseModel>(await this.VenueModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolVenueMapper.MapModelToBO(default(int), model);
				var record = await this.VenueRepository.Create(this.DalVenueMapper.MapBOToEF(bo));

				response.SetRecord(this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiVenueResponseModel>> Update(
			int id,
			ApiVenueRequestModel model)
		{
			var validationResult = await this.VenueModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolVenueMapper.MapModelToBO(id, model);
				await this.VenueRepository.Update(this.DalVenueMapper.MapBOToEF(bo));

				var record = await this.VenueRepository.Get(id);

				return new UpdateResponse<ApiVenueResponseModel>(this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiVenueResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.VenueModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.VenueRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiVenueResponseModel>> ByAdminId(int adminId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByAdminId(adminId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}

		public async Task<List<ApiVenueResponseModel>> ByProvinceId(int provinceId, int limit = 0, int offset = int.MaxValue)
		{
			List<Venue> records = await this.VenueRepository.ByProvinceId(provinceId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>60028d4860fd2bbf0bc390d32f579ece</Hash>
</Codenesium>*/