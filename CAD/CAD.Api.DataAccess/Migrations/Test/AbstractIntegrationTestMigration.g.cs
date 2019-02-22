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

			var callAssignmentItem1 = new CallAssignment();
			callAssignmentItem1.SetProperties(1, 1, 1);
			this.Context.CallAssignments.Add(callAssignmentItem1);

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

			var officerCapabilityItem1 = new OfficerCapability();
			officerCapabilityItem1.SetProperties(1, "A");
			this.Context.OfficerCapabilities.Add(officerCapabilityItem1);

			var officerRefCapabilityItem1 = new OfficerRefCapability();
			officerRefCapabilityItem1.SetProperties(1, 1, 1);
			this.Context.OfficerRefCapabilities.Add(officerRefCapabilityItem1);

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

			var unitOfficerItem1 = new UnitOfficer();
			unitOfficerItem1.SetProperties(1, 1, 1);
			this.Context.UnitOfficers.Add(unitOfficerItem1);

			var vehicleItem1 = new Vehicle();
			vehicleItem1.SetProperties(1, "A");
			this.Context.Vehicles.Add(vehicleItem1);

			var vehicleCapabilityItem1 = new VehicleCapability();
			vehicleCapabilityItem1.SetProperties(1, "A");
			this.Context.VehicleCapabilities.Add(vehicleCapabilityItem1);

			var vehicleOfficerItem1 = new VehicleOfficer();
			vehicleOfficerItem1.SetProperties(1, 1, 1);
			this.Context.VehicleOfficers.Add(vehicleOfficerItem1);

			var vehicleRefCapabilityItem1 = new VehicleRefCapability();
			vehicleRefCapabilityItem1.SetProperties(1, 1, 1);
			this.Context.VehicleRefCapabilities.Add(vehicleRefCapabilityItem1);

			await this.Context.SaveChangesAsync();
		}
	}
}

/*<Codenesium>
    <Hash>0d239de7f24b37ee6f944fb7f2bd6a8f</Hash>
</Codenesium>*/