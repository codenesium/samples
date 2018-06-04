using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractPasswordService: AbstractService
	{
		private IPasswordRepository passwordRepository;
		private IApiPasswordRequestModelValidator passwordModelValidator;
		private IBOLPasswordMapper BOLPasswordMapper;
		private IDALPasswordMapper DALPasswordMapper;
		private ILogger logger;

		public AbstractPasswordService(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper bolpasswordMapper,
			IDALPasswordMapper dalpasswordMapper)
			: base()

		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.BOLPasswordMapper = bolpasswordMapper;
			this.DALPasswordMapper = dalpasswordMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPasswordResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.passwordRepository.All(skip, take, orderClause);

			return this.BOLPasswordMapper.MapBOToModel(this.DALPasswordMapper.MapEFToBO(records));
		}

		public virtual async Task<ApiPasswordResponseModel> Get(int businessEntityID)
		{
			var record = await passwordRepository.Get(businessEntityID);

			return this.BOLPasswordMapper.MapBOToModel(this.DALPasswordMapper.MapEFToBO(record));
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model)
		{
			CreateResponse<ApiPasswordResponseModel> response = new CreateResponse<ApiPasswordResponseModel>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var bo = this.BOLPasswordMapper.MapModelToBO(default (int), model);
				var record = await this.passwordRepository.Create(this.DALPasswordMapper.MapBOToEF(bo));

				response.SetRecord(this.BOLPasswordMapper.MapBOToModel(this.DALPasswordMapper.MapEFToBO(record)));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPasswordRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var bo = this.BOLPasswordMapper.MapModelToBO(businessEntityID, model);
				await this.passwordRepository.Update(this.DALPasswordMapper.MapBOToEF(bo));
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.passwordModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.passwordRepository.Delete(businessEntityID);
			}
			return response;
		}
	}
}

/*<Codenesium>
    <Hash>cfa42bd1b5933249d5debfbc8e2e8cd4</Hash>
</Codenesium>*/