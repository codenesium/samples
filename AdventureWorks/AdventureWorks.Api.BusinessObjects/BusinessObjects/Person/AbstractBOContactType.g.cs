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
	public abstract class AbstractBOContactType: AbstractBOManager
	{
		private IContactTypeRepository contactTypeRepository;
		private IApiContactTypeRequestModelValidator contactTypeModelValidator;
		private IBOLContactTypeMapper contactTypeMapper;
		private ILogger logger;

		public AbstractBOContactType(
			ILogger logger,
			IContactTypeRepository contactTypeRepository,
			IApiContactTypeRequestModelValidator contactTypeModelValidator,
			IBOLContactTypeMapper contactTypeMapper)
			: base()

		{
			this.contactTypeRepository = contactTypeRepository;
			this.contactTypeModelValidator = contactTypeModelValidator;
			this.contactTypeMapper = contactTypeMapper;
			this.logger = logger;
		}

		public virtual async Task<List<ApiContactTypeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var records = await this.contactTypeRepository.All(skip, take, orderClause);

			return this.contactTypeMapper.MapDTOToModel(records);
		}

		public virtual async Task<ApiContactTypeResponseModel> Get(int contactTypeID)
		{
			var record = await contactTypeRepository.Get(contactTypeID);

			return this.contactTypeMapper.MapDTOToModel(record);
		}

		public virtual async Task<CreateResponse<ApiContactTypeResponseModel>> Create(
			ApiContactTypeRequestModel model)
		{
			CreateResponse<ApiContactTypeResponseModel> response = new CreateResponse<ApiContactTypeResponseModel>(await this.contactTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				var dto = this.contactTypeMapper.MapModelToDTO(default (int), model);
				var record = await this.contactTypeRepository.Create(dto);

				response.SetRecord(this.contactTypeMapper.MapDTOToModel(record));
			}
			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int contactTypeID,
			ApiContactTypeRequestModel model)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateUpdateAsync(contactTypeID, model));

			if (response.Success)
			{
				var dto = this.contactTypeMapper.MapModelToDTO(contactTypeID, model);
				await this.contactTypeRepository.Update(contactTypeID, dto);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int contactTypeID)
		{
			ActionResponse response = new ActionResponse(await this.contactTypeModelValidator.ValidateDeleteAsync(contactTypeID));

			if (response.Success)
			{
				await this.contactTypeRepository.Delete(contactTypeID);
			}
			return response;
		}

		public async Task<ApiContactTypeResponseModel> GetName(string name)
		{
			DTOContactType record = await this.contactTypeRepository.GetName(name);

			return this.contactTypeMapper.MapDTOToModel(record);
		}
	}
}

/*<Codenesium>
    <Hash>748bcca85a574c7fc40f466ac08f09f0</Hash>
</Codenesium>*/