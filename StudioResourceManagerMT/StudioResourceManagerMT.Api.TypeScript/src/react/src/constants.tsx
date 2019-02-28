export class Constants {
   static readonly BaseEndpoint = process.env.REACT_APP_API_URL;
   static readonly ApiEndpoint = Constants.BaseEndpoint + 'api/';
   static readonly ApiHealthEndpoint = Constants.ApiEndpoint + 'apiHealth';
   static readonly SwaggerEndpoint = Constants.BaseEndpoint + 'swagger';
}

export class ClientRoutes {
static readonly Admins = '/admins';		
static readonly Events = '/events';		
static readonly EventStatus = '/eventstatus';		
static readonly Families = '/families';		
static readonly Rates = '/rates';		
static readonly Spaces = '/spaces';		
static readonly SpaceFeatures = '/spacefeatures';		
static readonly Students = '/students';		
static readonly Studios = '/studios';		
static readonly Teachers = '/teachers';		
static readonly TeacherSkills = '/teacherskills';		
static readonly Users = '/users';		
}

export class ApiRoutes {
static readonly Admins = 'admins';		
static readonly Events = 'events';		
static readonly EventStatus = 'eventstatus';		
static readonly Families = 'families';		
static readonly Rates = 'rates';		
static readonly Spaces = 'spaces';		
static readonly SpaceFeatures = 'spacefeatures';		
static readonly Students = 'students';		
static readonly Studios = 'studios';		
static readonly Teachers = 'teachers';		
static readonly TeacherSkills = 'teacherskills';		
static readonly Users = 'users';		
}

/*<Codenesium>
    <Hash>6958ac49c3610f1c9cf56f97e2f52ea6</Hash>
</Codenesium>*/