using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractAdminService : AbstractService
	{
		private IMediator mediator;

		protected IAdminRepository AdminRepository { get; private set; }

		protected IApiAdminServerRequestModelValidator AdminModelValidator { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		protected IBOLVenueMapper BolVenueMapper { get; private set; }

		protected IDALVenueMapper DalVenueMapper { get; private set; }

		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IMediator mediator,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLVenueMapper bolVenueMapper,
			IDALVenueMapper dalVenueMapper)
			: base()
		{
			this.AdminRepository = adminRepository;
			this.AdminModelValidator = adminModelValidator;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.BolVenueMapper = bolVenueMapper;
			this.DalVenueMapper = dalVenueMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAdminServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.AdminRepository.All(limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiAdminServerResponseModel> Get(int id)
		{
			var record = await this.AdminRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiAdminServerResponseModel>> Create(
			ApiAdminServerRequestModel model)
		{
			CreateResponse<ApiAdminServerResponseModel> response = ValidationResponseFactory<ApiAdminServerResponseModel>.CreateResponse(await this.AdminModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolAdminMapper.MapModelToBO(default(int), model);
				var record = await this.AdminRepository.Create(this.DalAdminMapper.MapBOToEF(bo));

				var businessObject = this.DalAdminMapper.MapEFToBO(record);
				response.SetRecord(this.BolAdminMapper.MapBOToModel(businessObject));
				await this.mediator.Publish(new AdminCreatedNotification(response.Record));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiAdminServerResponseModel>> Update(
			int id,
			ApiAdminServerRequestModel model)
		{
			var validationResult = await this.AdminModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolAdminMapper.MapModelToBO(id, model);
				await this.AdminRepository.Update(this.DalAdminMapper.MapBOToEF(bo));

				var record = await this.AdminRepository.Get(id);

				var businessObject = this.DalAdminMapper.MapEFToBO(record);
				var apiModel = this.BolAdminMapper.MapBOToModel(businessObject);
				await this.mediator.Publish(new AdminUpdatedNotification(apiModel));

				return ValidationResponseFactory<ApiAdminServerResponseModel>.UpdateResponse(apiModel);
			}
			else
			{
				return ValidationResponseFactory<ApiAdminServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.AdminModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.AdminRepository.Delete(id);

				await this.mediator.Publish(new AdminDeletedNotification(id));
			}

			return response;
		}

		public async virtual Task<List<ApiVenueServerResponseModel>> VenuesByAdminId(int adminId, int limit = int.MaxValue, int offset = 0)
		{
			List<Venue> records = await this.AdminRepository.VenuesByAdminId(adminId, limit, offset);

			return this.BolVenueMapper.MapBOToModel(this.DalVenueMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>4fd5c085e764c28613de1b9cf51ef846</Hash>
</Codenesium>*/