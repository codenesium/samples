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
	public abstract class AbstractUserService : AbstractService
	{
		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserRequestModelValidator UserModelValidator { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			IUserRepository userRepository,
			IApiUserRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base()
		{
			this.UserRepository = userRepository;
			this.UserModelValidator = userModelValidator;
			this.BolUserMapper = bolUserMapper;
			this.DalUserMapper = dalUserMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUserResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRepository.All(limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserResponseModel> Get(string id)
		{
			var record = await this.UserRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUserResponseModel>> Create(
			ApiUserRequestModel model)
		{
			CreateResponse<ApiUserResponseModel> response = new CreateResponse<ApiUserResponseModel>(await this.UserModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUserMapper.MapModelToBO(default(string), model);
				var record = await this.UserRepository.Create(this.DalUserMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserResponseModel>> Update(
			string id,
			ApiUserRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserMapper.MapModelToBO(id, model);
				await this.UserRepository.Update(this.DalUserMapper.MapBOToEF(bo));

				var record = await this.UserRepository.Get(id);

				return new UpdateResponse<ApiUserResponseModel>(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUserResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			string id)
		{
			ActionResponse response = new ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.UserRepository.Delete(id);
			}

			return response;
		}

		public async Task<ApiUserResponseModel> ByUsername(string username)
		{
			User record = await this.UserRepository.ByUsername(username);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record));
			}
		}

		public async Task<List<ApiUserResponseModel>> ByDisplayName(string displayName, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByDisplayName(displayName, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public async Task<List<ApiUserResponseModel>> ByEmailAddress(string emailAddress, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByEmailAddress(emailAddress, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public async Task<List<ApiUserResponseModel>> ByExternalId(string externalId, int limit = 0, int offset = int.MaxValue)
		{
			List<User> records = await this.UserRepository.ByExternalId(externalId, limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>de484e74da5bbb436f5674346abc7199</Hash>
</Codenesium>*/