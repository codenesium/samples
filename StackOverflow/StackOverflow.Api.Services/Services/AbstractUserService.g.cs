using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractUserService : AbstractService
	{
		protected IUserRepository UserRepository { get; private set; }

		protected IApiUserServerRequestModelValidator UserModelValidator { get; private set; }

		protected IBOLUserMapper BolUserMapper { get; private set; }

		protected IDALUserMapper DalUserMapper { get; private set; }

		private ILogger logger;

		public AbstractUserService(
			ILogger logger,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
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

		public virtual async Task<List<ApiUserServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UserRepository.All(limit, offset);

			return this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUserServerResponseModel> Get(int id)
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

		public virtual async Task<CreateResponse<ApiUserServerResponseModel>> Create(
			ApiUserServerRequestModel model)
		{
			CreateResponse<ApiUserServerResponseModel> response = ValidationResponseFactory<ApiUserServerResponseModel>.CreateResponse(await this.UserModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolUserMapper.MapModelToBO(default(int), model);
				var record = await this.UserRepository.Create(this.DalUserMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUserServerResponseModel>> Update(
			int id,
			ApiUserServerRequestModel model)
		{
			var validationResult = await this.UserModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUserMapper.MapModelToBO(id, model);
				await this.UserRepository.Update(this.DalUserMapper.MapBOToEF(bo));

				var record = await this.UserRepository.Get(id);

				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(this.BolUserMapper.MapBOToModel(this.DalUserMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiUserServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.UserModelValidator.ValidateDeleteAsync(id));

			if (response.Success)
			{
				await this.UserRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>a23db4f7f1a3b145f03ae10746568678</Hash>
</Codenesium>*/