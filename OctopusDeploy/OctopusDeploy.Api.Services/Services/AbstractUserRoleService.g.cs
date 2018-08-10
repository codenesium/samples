using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public abstract class AbstractUserRoleService : AbstractService
	{
		protected IUserRoleRepository UserRoleRepository { get; private set; }

		protected IApiUserRoleRequestModelValidator UserRoleModelValidator { get; private set; }

		protected IBOLUserRoleMapper BolUserRoleMapper { get; private set; }

		protected IDALUserRoleMapper DalUserRoleMapper { get; private set; }

		private ILogger logger;

		public AbstractUserRoleService(
			ILogger logger,
			IUserRoleRepository userRoleRepository,
			IApiUserRoleRequestModelValidator userRoleModelValidator,
			IBOLUserRoleMapper bolUserRoleMapper,
			IDALUserRoleMapper dalUserRoleMapper)
			: base()
		{
			this.UserRoleRepository = userRoleRepository;
			this.UserRoleModelValidator = userRoleModelValidator;
			this.BolUserRoleMapper = bolUserRoleMapper;
			this.DalUserRoleMapper = dalUserRoleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserRoleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRoleRepository.All(limit, offset);

			return this.BolUserRoleMapper.MapBOToModel(this.DalUserRoleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserRoleResponseModel> Get(string id)
		{
			var record = await this.UserRoleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserRoleMapper.MapBOToModel(this.DalUserRoleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserRoleResponseModel>> Create(
			ApiUserRoleRequestModel model)
		{
			CreateResponse<ApiUserRoleResponseModel> response = new CreateResponse<ApiUserRoleResponseModel>(await this.UserRoleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUserRoleMapper.MapModelToBO(default(string), model);
				var record = await this.UserRoleRepository.Create(this.DalUserRoleMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserRoleMapper.MapBOToModel(this.DalUserRoleMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserRoleResponseModel>> Update(
			string id,
			ApiUserRoleRequestModel model)
		{
			var validationResult = await this.UserRoleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserRoleMapper.MapModelToBO(id, model);
				await this.UserRoleRepository.Update(this.DalUserRoleMapper.MapBOToEF(bo));

				var record = await this.UserRoleRepository.Get(id);

				return new UpdateResponse<ApiUserRoleResponseModel>(this.BolUserRoleMapper.MapBOToModel(this.DalUserRoleMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUserRoleResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.UserRoleModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.UserRoleRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiUserRoleResponseModel> ByName(string name)
		{
			UserRole record = await this.UserRoleRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserRoleMapper.MapBOToModel(this.DalUserRoleMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>72d35029fccb87a994c78b9b02d4a29a</Hash>
</Codenesium>*/