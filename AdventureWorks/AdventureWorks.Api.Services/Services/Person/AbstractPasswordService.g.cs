using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService : AbstractService
	{
		protected IPasswordRepository PasswordRepository { get; private set; }

		protected IApiPasswordRequestModelValidator PasswordModelValidator { get; private set; }

		protected IBOLPasswordMapper BolPasswordMapper { get; private set; }

		protected IDALPasswordMapper DalPasswordMapper { get; private set; }

		private ILogger logger;

		public AbstractPasswordService(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolPasswordMapper,
			IDALPasswordMapper dalPasswordMapper)
			: base()
		{
			this.PasswordRepository = passwordRepository;
			this.PasswordModelValidator = passwordModelValidator;
			this.BolPasswordMapper = bolPasswordMapper;
			this.DalPasswordMapper = dalPasswordMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPasswordResponseModel>> All(int limit = 0, int offset = int.MaxValue)
		{
			var records = await this.PasswordRepository.All(limit, offset);

			return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPasswordResponseModel> Get(int businessEntityID)
		{
			var record = await this.PasswordRepository.Get(businessEntityID);

			if (record == null)
			{
				return null;
			}
			else
			{
				return this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(record));
			}
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model)
		{
			CreateResponse<ApiPasswordResponseModel> response = new CreateResponse<ApiPasswordResponseModel>(await this.PasswordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BolPasswordMapper.MapModelToBO(default(int), model);
				var record = await this.PasswordRepository.Create(this.DalPasswordMapper.MapBOToEF(bo));

				response.SetRecord(this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(record)));
			}

			return response;
		}

		public virtual async Task<UpdateResponse<ApiPasswordResponseModel>> Update(
			int businessEntityID,
			ApiPasswordRequestModel model)
		{
			var validationResult = await this.PasswordModelValidator.ValidateUpdateAsync(businessEntityID, model);

			if (validationResult.IsValid)
			{
				var bo = this.BolPasswordMapper.MapModelToBO(businessEntityID, model);
				await this.PasswordRepository.Update(this.DalPasswordMapper.MapBOToEF(bo));

				var record = await this.PasswordRepository.Get(businessEntityID);

				return new UpdateResponse<ApiPasswordResponseModel>(this.BolPasswordMapper.MapBOToModel(this.DalPasswordMapper.MapEFToBO(record)));
			}
			else
			{
				return new UpdateResponse<ApiPasswordResponseModel>(validationResult);
			}
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.PasswordModelValidator.ValidateDeleteAsync(businessEntityID));
			if (response.Success)
			{
				await this.PasswordRepository.Delete(businessEntityID);
			}

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>d753869dd6b360b5c6a4cd67e6566ab1</Hash>
</Codenesium>*/