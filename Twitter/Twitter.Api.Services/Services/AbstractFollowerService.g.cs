using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractFollowerService : AbstractService
	{
		protected IFollowerRepository FollowerRepository { get; private set; }

		protected IApiFollowerRequestModelValidator FollowerModelValidator { get; private set; }

		protected IBOLFollowerMapper BolFollowerMapper { get; private set; }

		protected IDALFollowerMapper DalFollowerMapper { get; private set; }

		private ILogger logger;

		public AbstractFollowerService(
			ILogger logger,
			IFollowerRepository followerRepository,
			IApiFollowerRequestModelValidator followerModelValidator,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper)
			: base()
		{
			this.FollowerRepository = followerRepository;
			this.FollowerModelValidator = followerModelValidator;
			this.BolFollowerMapper = bolFollowerMapper;
			this.DalFollowerMapper = dalFollowerMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiFollowerResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.FollowerRepository.All(limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiFollowerResponseModel> Get(int id)
		{
			var record = await this.FollowerRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiFollowerResponseModel>> Create(
			ApiFollowerRequestModel model)
		{
			CreateResponse<ApiFollowerResponseModel> response = new CreateResponse<ApiFollowerResponseModel>(await this.FollowerModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolFollowerMapper.MapModelToBO(default(int), model);
				var record = await this.FollowerRepository.Create(this.DalFollowerMapper.MapBOToEF(bo));

				response.SetRecord(this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiFollowerResponseModel>> Update(
			int id,
			ApiFollowerRequestModel model)
		{
			var validationResult = await this.FollowerModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolFollowerMapper.MapModelToBO(id, model);
				await this.FollowerRepository.Update(this.DalFollowerMapper.MapBOToEF(bo));

				var record = await this.FollowerRepository.Get(id);

				return new UpdateResponse<ApiFollowerResponseModel>(this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiFollowerResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.FollowerModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.FollowerRepository.Delete(id);
			}

			return response;
		}

		public async Task<List<ApiFollowerResponseModel>> ByFollowedUserId(int followedUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Follower> records = await this.FollowerRepository.ByFollowedUserId(followedUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}

		public async Task<List<ApiFollowerResponseModel>> ByFollowingUserId(int followingUserId, int limit = 0, int offset = int.MaxValue)
		{
			List<Follower> records = await this.FollowerRepository.ByFollowingUserId(followingUserId, limit, offset);

			return this.BolFollowerMapper.MapBOToModel(this.DalFollowerMapper.MapEFToBO(records));
		}
	}
}

/*<Codenesium>
    <Hash>8d062fa1576cf027f4531e4852060d1a</Hash>
</Codenesium>*/