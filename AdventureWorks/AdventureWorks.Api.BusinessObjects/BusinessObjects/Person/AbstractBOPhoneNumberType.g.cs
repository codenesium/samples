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
	public abstract class AbstractBOPhoneNumberType
	{
		private IPhoneNumberTypeRepository phoneNumberTypeRepository;
		private IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator;
		private ILogger logger;

		public AbstractBOPhoneNumberType(
			ILogger logger,
			IPhoneNumberTypeRepository phoneNumberTypeRepository,
			IPhoneNumberTypeModelValidator phoneNumberTypeModelValidator)

		{
			this.phoneNumberTypeRepository = phoneNumberTypeRepository;
			this.phoneNumberTypeModelValidator = phoneNumberTypeModelValidator;
			this.logger = logger;
		}

		public virtual async Task<CreateResponse<int>> Create(
			PhoneNumberTypeModel model)
		{
			CreateResponse<int> response = new CreateResponse<int>(await this.phoneNumberTypeModelValidator.ValidateCreateAsync(model));
			if (response.Success)
			{
				int id = this.phoneNumberTypeRepository.Create(model);
				response.SetId(id);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Update(
			int phoneNumberTypeID,
			PhoneNumberTypeModel model)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateUpdateAsync(phoneNumberTypeID, model));

			if (response.Success)
			{
				this.phoneNumberTypeRepository.Update(phoneNumberTypeID, model);
			}

			return response;
		}

		public virtual async Task<ActionResponse> Delete(
			int phoneNumberTypeID)
		{
			ActionResponse response = new ActionResponse(await this.phoneNumberTypeModelValidator.ValidateDeleteAsync(phoneNumberTypeID));

			if (response.Success)
			{
				this.phoneNumberTypeRepository.Delete(phoneNumberTypeID);
			}
			return response;
		}

		public virtual ApiResponse GetById(int phoneNumberTypeID)
		{
			return this.phoneNumberTypeRepository.GetById(phoneNumberTypeID);
		}

		public virtual POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID)
		{
			return this.phoneNumberTypeRepository.GetByIdDirect(phoneNumberTypeID);
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.GetWhere(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.GetWhereDynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.phoneNumberTypeRepository.GetWhereDirect(predicate, skip, take, orderClause);
		}
	}
}

/*<Codenesium>
    <Hash>d81357245103d370876411cd36c083d3</Hash>
</Codenesium>*/