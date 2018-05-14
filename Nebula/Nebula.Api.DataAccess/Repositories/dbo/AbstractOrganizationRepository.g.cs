using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public abstract class AbstractOrganizationRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractOrganizationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOOrganization> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOOrganization Get(int id)
		{
			return this.SearchLinqPOCO(x => x.Id == id).FirstOrDefault();
		}

		public virtual POCOOrganization Create(
			OrganizationModel model)
		{
			Organization record = new Organization();

			this.Mapper.OrganizationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Organization>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.OrganizationMapEFToPOCO(record);
		}

		public virtual void Update(
			int id,
			OrganizationModel model)
		{
			Organization record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.OrganizationMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			Organization record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Organization>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOOrganization Name(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOOrganization> Where(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOOrganization> SearchLinqPOCO(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOOrganization> response = new List<POCOOrganization>();
			List<Organization> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.OrganizationMapEFToPOCO(x)));
			return response;
		}

		private List<Organization> SearchLinqEF(Expression<Func<Organization, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Organization.Id)} ASC";
			}
			return this.Context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
		}

		private List<Organization> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Organization.Id)} ASC";
			}

			return this.Context.Set<Organization>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Organization>();
		}
	}
}

/*<Codenesium>
    <Hash>b319445fedc822729bb816b8280bf408</Hash>
</Codenesium>*/