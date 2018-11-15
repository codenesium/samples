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
		protected IAdminRepository AdminRepository { get; private set; }

		protected IApiAdminServerRequestModelValidator AdminModelValidator { get; private set; }

		protected IBOLAdminMapper BolAdminMapper { get; private set; }

		protected IDALAdminMapper DalAdminMapper { get; private set; }

		private ILogger logger;

		public AbstractAdminService(
			ILogger logger,
			IAdminRepository adminRepository,
			IApiAdminServerRequestModelValidator adminModelValidator,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper)
			: base()
		{
			this.AdminRepository = adminRepository;
			this.AdminModelValidator = adminModelValidator;
			this.BolAdminMapper = bolAdminMapper;
			this.DalAdminMapper = dalAdminMapper;
			this.logger = logger;
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

				response.SetRecord(this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record)));
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

				return ValidationResponseFactory<ApiAdminServerResponseModel>.UpdateResponse(this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(record)));
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
			}

			return response;
		}

		public async virtual Task<List<ApiAdminServerResponseModel>> ByUserId(int userId, int limit = 0, int offset = int.MaxValue)
		{
			List<Admin> records = await this.AdminRepository.ByUserId(userId, limit, offset);

			return this.BolAdminMapper.MapBOToModel(this.DalAdminMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>84a209722bf4409a6ad67b7ac51149e4</Hash>
</Codenesium>*/