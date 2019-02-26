using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace CADNS.Api.DataAccess
{
	public abstract class AbstractIntegrationTestMigration
	{
		protected ApplicationDbContext Context { get; private set; }

		public AbstractIntegrationTestMigration(ApplicationDbContext context)
		{
			this.Context = context;
		}

		public virtual async Task Migrate()
		{
			var addressItem1 = new Address();
			addressItem1.SetProperties(1, "A", "A", "A", "A", "A");
			this.Context.Addresses.Add(addressItem1);

			var callItem1 = new Call();
			callItem1.SetProperties(1, 1, 1, 1, "A", 1, DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), DateTime.Parse("1/1/1987 12:00:00 AM"), 1);
			this.Context.Calls.Add(callItem1);

			var callDispositionItem1 = new CallDisposition();
			callDispositionItem1.SetProperties(1, "A");
			this.Context.CallDispositions.Add(callDispositionItem1);

			var callPersonItem1 = new CallPerson();
			callPersonItem1.SetProperties(1, "A", 1, 1);
			this.Context.CallPersons.Add(callPersonItem1);

			var callStatuItem1 = new CallStatu();
			callStatuItem1.SetProperties(1, "A");
			this.Context.CallStatus.Add(callStatuItem1);

			var callTypeItem1 = new CallType();
			callTypeItem1.SetProperties(1, "A");
			this.Context.CallTypes.Add(callTypeItem1);

			var noteItem1 = new Note();
			noteItem1.SetProperties(1, 1, DateTime.Parse("1/1/1987 12:00:00 AM"), "A", 1);
			this.Context.Notes.Add(noteItem1);

			var officerItem1 = new Officer();
			officerItem1.SetProperties(1, "A", "A", "A", "A", "A");
			this.Context.Officers.Add(officerItem1);

			var officerCapabilitiesItem1 = new OfficerCapabilities();
			officerCapabilitiesItem1.SetProperties(1, 1);
			this.Context.OfficerCapabilities.Add(officerCapabilitiesItem1);

			var personItem1 = new Person();
			personItem1.SetProperties(1, "A", "A", "A", "A");
			this.Context.People.Add(personItem1);

			var personTypeItem1 = new PersonType();
			personTypeItem1.SetProperties(1, "A");
			this.Context.PersonTypes.Add(personTypeItem1);

			var unitItem1 = new Unit();
			unitItem1.SetProperties(1, "A");
			this.Context.Units.Add(unitItem1);

			var unitDispositionItem1 = new UnitDisposition();
			unitDispositionItem1.SetProperties(1, "A");
			this.Context.UnitDispositions.Add(unitDispositionItem1);

			var vehicleItem1 = new Vehicle();
			vehicleItem1.SetProperties(1, "A");
			this.Context.Vehicles.Add(vehicleItem1);

			var vehicleCapabilitiesItem1 = new VehicleCapabilities();
			vehicleCapabilitiesItem1.SetProperties(1, 1);
			this.Context.VehicleCapabilities.Add(vehicleCapabilitiesItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>7403152ccb3bb7a3bcaa3172690b2f9d</Hash>
</Codenesium>*/