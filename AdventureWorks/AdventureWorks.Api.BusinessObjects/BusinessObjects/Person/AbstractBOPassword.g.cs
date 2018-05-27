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

namespace AdventureWorksNS.Api.BusinessObjects
{
	public abstract class AbstractBOPassword: AbstractBOManager
	{
		private IPasswordRepository passwordRepository;
		private IApiPasswordRequestModelValidator passwordModelValidator;
		private IBOLPasswordMapper passwordMapper;
		private ILogger logger;

		public AbstractBOPassword(
			ILogger logger,
			IPasswordRepository passwordRepository,
			IApiPasswordRequestModelValidator passwordModelValidator,
			IBOLPasswordMapper passwordMapper)
			: base()

		{
			this.passwordRepository = passwordRepository;
			this.passwordModelValidator = passwordModelValidator;
			this.passwordMapper = passwordMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPasswordResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.passwordRepository.All(skip, take, orderClause);

			return this.passwordMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPasswordResponseModel> Get(int businessEntityID)
		{
			var record = await passwordRepository.Get(businessEntityID);

			return this.passwordMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPasswordResponseModel>> Create(
			ApiPasswordRequestModel model)
		{
			CreateResponse<ApiPasswordResponseModel> response = new CreateResponse<ApiPasswordResponseModel>(await this.passwordModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.passwordMapper.MapModelToDTO(default (int), model);
				var record = await this.passwordRepository.Create(dto);

				response.SetRecord(this.passwordMapper.MapDTOToModel(record));
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
				var dto = this.passwordMapper.MapModelToDTO(businessEntityID, model);
				await this.passwordRepository.Update(businessEntityID, dto);
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
    <Hash>a16b02ceb79bc1d95308e82286984e41</Hash>
</Codenesium>*/