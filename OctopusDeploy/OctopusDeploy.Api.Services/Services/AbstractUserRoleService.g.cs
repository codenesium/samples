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
		private IUserRoleRepository userRoleRepository;

		private IApiUserRoleRequestModelValidator userRoleModelValidator;

		private IBOLUserRoleMapper bolUserRoleMapper;

		private IDALUserRoleMapper dalUserRoleMapper;

		private ILogger logger;

		public AbstractUserRoleService(
			ILogger logger,
			IUserRoleRepository userRoleRepository,
			IApiUserRoleRequestModelValidator userRoleModelValidator,
			IBOLUserRoleMapper bolUserRoleMapper,
			IDALUserRoleMapper dalUserRoleMapper)
			: base()
		{
			this.userRoleRepository = userRoleRepository;
			this.userRoleModelValidator = userRoleModelValidator;
			this.bolUserRoleMapper = bolUserRoleMapper;
			this.dalUserRoleMapper = dalUserRoleMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserRoleResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.userRoleRepository.All(limit, offset);

			return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserRoleResponseModel> Get(string id)
		{
			var record = await this.userRoleRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserRoleResponseModel>> Create(
			ApiUserRoleRequestModel model)
		{
			CreateResponse<ApiUserRoleResponseModel> response = new CreateResponse<ApiUserRoleResponseModel>(await this.userRoleModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.bolUserRoleMapper.MapModelToBO(default(string), model);
				var record = await this.userRoleRepository.Create(this.dalUserRoleMapper.MapBOToEF(bo));

				response.SetRecord(this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserRoleResponseModel>> Update(
			string id,
			ApiUserRoleRequestModel model)
		{
			var validationResult = await this.userRoleModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.bolUserRoleMapper.MapModelToBO(id, model);
				await this.userRoleRepository.Update(this.dalUserRoleMapper.MapBOToEF(bo));

				var record = await this.userRoleRepository.Get(id);

				return new UpdateResponse<ApiUserRoleResponseModel>(this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUserRoleResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.userRoleModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.userRoleRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiUserRoleResponseModel> ByName(string name)
		{
			UserRole record = await this.userRoleRepository.ByName(name);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.bolUserRoleMapper.MapBOToModel(this.dalUserRoleMapper.MapEFToBO(record));
			}
		}
	}
}

/*<Codenesium>
    <Hash>55168289dee7aebaae9bdea35855ebe1</Hash>
</Codenesium>*/