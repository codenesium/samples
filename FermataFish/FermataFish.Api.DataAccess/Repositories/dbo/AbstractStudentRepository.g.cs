using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudentRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled)
		{
			var record = new EFStudent();

			MapPOCOToEF(
				0,
				email,
				firstName,
				lastName,
				phone,
				isAdult,
				birthday,
				familyId,
				studioId,
				smsRemindersEnabled,
				emailRemindersEnabled,
				record);

			this.context.Set<EFStudent>().Add(record);
			this.context.SaveChanges();
			return record.Id;
		}

		public virtual void Update(
			int id,
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{id}");
			}
			else
			{
				MapPOCOToEF(
					id,
					email,
					firstName,
					lastName,
					phone,
					isAdult,
					birthday,
					familyId,
					studioId,
					smsRemindersEnabled,
					emailRemindersEnabled,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int id)
		{
			var record = this.SearchLinqEF(x => x.Id == id).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFStudent>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response;
		}

		public virtual POCOStudent GetByIdDirect(int id)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.Id == id, response);
			return response.Students.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOStudent> GetWhereDirect(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Students;
		}

		private void SearchLinqPOCO(Expression<Func<EFStudent, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudent> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStudent> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFStudent> SearchLinqEF(Expression<Func<EFStudent, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStudent> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int id,
			string email,
			string firstName,
			string lastName,
			string phone,
			bool isAdult,
			DateTime birthday,
			int familyId,
			int studioId,
			bool smsRemindersEnabled,
			bool emailRemindersEnabled,
			EFStudent efStudent)
		{
			efStudent.SetProperties(id.ToInt(), email, firstName, lastName, phone, isAdult, birthday, familyId.ToInt(), studioId.ToInt(), smsRemindersEnabled, emailRemindersEnabled);
		}

		public static void MapEFToPOCO(
			EFStudent efStudent,
			Response response)
		{
			if (efStudent == null)
			{
				return;
			}

			response.AddStudent(new POCOStudent(efStudent.Id.ToInt(), efStudent.Email, efStudent.FirstName, efStudent.LastName, efStudent.Phone, efStudent.IsAdult, efStudent.Birthday, efStudent.FamilyId.ToInt(), efStudent.StudioId.ToInt(), efStudent.SmsRemindersEnabled, efStudent.EmailRemindersEnabled));

			FamilyRepository.MapEFToPOCO(efStudent.Family, response);

			StudioRepository.MapEFToPOCO(efStudent.Studio, response);
		}
	}
}

/*<Codenesium>
    <Hash>891e62efcb84988c49838ce3ae89b26c</Hash>
</Codenesium>*/