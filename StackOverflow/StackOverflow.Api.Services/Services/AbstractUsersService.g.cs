using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractUsersService : AbstractService
	{
		protected IUsersRepository UsersRepository { get; private set; }

		protected IApiUsersRequestModelValidator UsersModelValidator { get; private set; }

		protected IBOLUsersMapper BolUsersMapper { get; private set; }

		protected IDALUsersMapper DalUsersMapper { get; private set; }

		private ILogger logger;

		public AbstractUsersService(
			ILogger logger,
			IUsersRepository usersRepository,
			IApiUsersRequestModelValidator usersModelValidator,
			IBOLUsersMapper bolUsersMapper,
			IDALUsersMapper dalUsersMapper)
			: base()
		{
			this.UsersRepository = usersRepository;
			this.UsersModelValidator = usersModelValidator;
			this.BolUsersMapper = bolUsersMapper;
			this.DalUsersMapper = dalUsersMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiUsersResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.UsersRepository.All(limit, offset);

			return this.BolUsersMapper.MapBOToModel(this.DalUsersMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiUsersResponseModel> Get(int id)
		{
			var record = await this.UsersRepository.Get(id);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolUsersMapper.MapBOToModel(this.DalUsersMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiUsersResponseModel>> Create(
			ApiUsersRequestModel model)
		{
			CreateResponse<ApiUsersResponseModel> response = new CreateResponse<ApiUsersResponseModel>(await this.UsersModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolUsersMapper.MapModelToBO(default(int), model);
				var record = await this.UsersRepository.Create(this.DalUsersMapper.MapBOToEF(bo));

				response.SetRecord(this.BolUsersMapper.MapBOToModel(this.DalUsersMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiUsersResponseModel>> Update(
			int id,
			ApiUsersRequestModel model)
		{
			var validationResult = await this.UsersModelValidator.ValidateUpdateAsync(id, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolUsersMapper.MapModelToBO(id, model);
				await this.UsersRepository.Update(this.DalUsersMapper.MapBOToEF(bo));

				var record = await this.UsersRepository.Get(id);

				return new UpdateResponse<ApiUsersResponseModel>(this.BolUsersMapper.MapBOToModel(this.DalUsersMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiUsersResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int id)
		{
			ActionResponse response = new ActionResponse(await this.UsersModelValidator.ValidateDeleteAsync(id));
			if (response.Success)
			{
				await this.UsersRepository.Delete(id);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>2c2995558c5b46a754f265c325b37d91</Hash>
</Codenesium>*/