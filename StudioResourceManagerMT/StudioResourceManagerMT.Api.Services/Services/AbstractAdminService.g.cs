using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public abstract class AbstractAdminService : AbstractService
	{
		private IMediator mediator;

		protected IAdminRepository AdminRepository { get; private set; }

		protected IApiAdminServerRequestModelValidator AdminModelValidator { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IMediator mediator,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IDALAdminMapper dalAdminMapper)
			: base()
		{
			this.AdminRepository = adminRepository;
			this.AdminModelValidator = adminModelValidator;
			this.DalAdminMapper = dalAdminMapper;
			this.logger = logger;

			this.mediator = mediator;
		}

		public virtual async Task<List<ApiAdminServerResponseModel>> All(int limit = 0, int offset = int.MaxValue, string query = "")
		{
			List<Admin> records = await this.AdminRepository.All(limit, offset, query);

			return this.DalAdminMapper.MapEntityToModel(records);
		}

		public virtual async Task<ApiAdminServerResponseModel> Get(int id)
		{
			Admin record = await this.AdminRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.DalAdminMapper.MapEntityToModel(record);
			}
		}

		public virtual async Task<CreateResponse<ApiAdminServerResponseModel>> Create(
			ApiAdminServerRequestModel model)
		{
			CreateResponse<ApiAdminServerResponseModel> response = ValidationResponseFactory<ApiAdminServerResponseModel>.CreateResponse(await this.AdminModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				Admin record = this.DalAdminMapper.MapModelToEntity(default(int), model);
				record = await this.AdminRepository.Create(record);

				response.SetRecord(this.DalAdminMapper.MapEntityToModel(record));
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
				Admin record = this.DalAdminMapper.MapModelToEntity(id, model);
				await this.AdminRepository.Update(record);

				record = await this.AdminRepository.Get(id);

				ApiAdminServerResponseModel apiModel = this.DalAdminMapper.MapEntityToModel(record);
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

		public async virtual Task<List<ApiAdminServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Admin> records = await this.AdminRepository.ByUserId(userId, limit, offset);

			return this.DalAdminMapper.MapEntityToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>91bc5b28d0ad9023a5d09b08b3528fa6</Hash>
</Codenesium>*/