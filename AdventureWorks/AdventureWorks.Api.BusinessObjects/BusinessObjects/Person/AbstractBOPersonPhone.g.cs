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
	public abstract class AbstractBOPersonPhone: AbstractBOManager
	{
		private IPersonPhoneRepository personPhoneRepository;
		private IApiPersonPhoneRequestModelValidator personPhoneModelValidator;
		private IBOLPersonPhoneMapper personPhoneMapper;
		private ILogger logger;

		public AbstractBOPersonPhone(
			ILogger logger,
			IPersonPhoneRepository personPhoneRepository,
			IApiPersonPhoneRequestModelValidator personPhoneModelValidator,
			IBOLPersonPhoneMapper personPhoneMapper)
			: base()

		{
			this.personPhoneRepository = personPhoneRepository;
			this.personPhoneModelValidator = personPhoneModelValidator;
			this.personPhoneMapper = personPhoneMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiPersonPhoneResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.personPhoneRepository.All(skip, take, orderClause);

			return this.personPhoneMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiPersonPhoneResponseModel> Get(int businessEntityID)
		{
			var record = await personPhoneRepository.Get(businessEntityID);

			return this.personPhoneMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiPersonPhoneResponseModel>> Create(
			ApiPersonPhoneRequestModel model)
		{
			CreateResponse<ApiPersonPhoneResponseModel> response = new CreateResponse<ApiPersonPhoneResponseModel>(await this.personPhoneModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.personPhoneMapper.MapModelToDTO(default (int), model);
				var record = await this.personPhoneRepository.Create(dto);

				response.SetRecord(this.personPhoneMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int businessEntityID,
			ApiPersonPhoneRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateUpdateAsync(businessEntityID, model));

			if (response.Success)
			{
				var dto = this.personPhoneMapper.MapModelToDTO(businessEntityID, model);
				await this.personPhoneRepository.Update(businessEntityID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int businessEntityID)
		{
			ActionResponse response = new ActionResponse(await this.personPhoneModelValidator.ValidateDeleteAsync(businessEntityID));

			if (response.Success)
			{
				await this.personPhoneRepository.Delete(businessEntityID);
			}
			return response;
		}

		public async Task<List<ApiPersonPhoneResponseModel>> GetPhoneNumber(string phoneNumber)
		{
			List<DTOPersonPhone> records = await this.personPhoneRepository.GetPhoneNumber(phoneNumber);

			return this.personPhoneMapper.MapDTOToModel(records);
		}
	}
}

/*<Codenesium>
    <Hash>9ea5c9c0be43af4d01ff11c2a01e9864</Hash>
</Codenesium>*/