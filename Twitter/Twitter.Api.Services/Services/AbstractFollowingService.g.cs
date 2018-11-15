using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractFollowingService : AbstractService
	{
		protected IFollowingRepository FollowingRepository { get; private set; }

		protected IApiFollowingServerRequestModelValidator FollowingModelValidator { get; private set; }

		protected IBOLFollowingMapper BolFollowingMapper { get; private set; }

		protected IDALFollowingMapper DalFollowingMapper { get; private set; }

		private ILogger logger;

		public AbstractFollowingService(
			ILogger logger,
			IFollowingRepository followingRepository,
			IApiFollowingServerRequestModelValidator followingModelValidator,
			IBOLFollowingMapper bolFollowingMapper,
			IDALFollowingMapper dalFollowingMapper)
			: base()
		{
			this.FollowingRepository = followingRepository;
			this.FollowingModelValidator = followingModelValidator;
			this.BolFollowingMapper = bolFollowingMapper;
			this.DalFollowingMapper = dalFollowingMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFollowingServerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FollowingRepository.All(limit, offset);

			return this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFollowingServerResponseModel> Get(int userId)
		{
			var record = await this.FollowingRepository.Get(userId);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFollowingServerResponseModel>> Create(
			ApiFollowingServerRequestModel model)
		{
			CreateResponse<ApiFollowingServerResponseModel> response = ValidationResponseFactory<ApiFollowingServerResponseModel>.CreateResponse(await this.FollowingModelValidator.ValidateCreateAsync(model));

			if (response.Success)
			{
				var bo = this.BolFollowingMapper.MapModelToBO(default(int), model);
				var record = await this.FollowingRepository.Create(this.DalFollowingMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFollowingServerResponseModel>> Update(
			int userId,
			ApiFollowingServerRequestModel model)
		{
			var validationResult = await this.FollowingModelValidator.ValidateUpdateAsync(userId, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFollowingMapper.MapModelToBO(userId, model);
				await this.FollowingRepository.Update(this.DalFollowingMapper.MapBOToEF(bo));

				var record = await this.FollowingRepository.Get(userId);

				return ValidationResponseFactory<ApiFollowingServerResponseModel>.UpdateResponse(this.BolFollowingMapper.MapBOToModel(this.DalFollowingMapper.MapEFToBO(record)));
			}
			else
			{
				return ValidationResponseFactory<ApiFollowingServerResponseModel>.UpdateResponse(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int userId)
		{
			ActionResponse response = ValidationResponseFactory<object>.ActionResponse(await this.FollowingModelValidator.ValidateDeleteAsync(userId));

			if (response.Success)
			{
				await this.FollowingRepository.Delete(userId);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>9f1623151922dd85b1689ff757555b39</Hash>
</Codenesium>*/