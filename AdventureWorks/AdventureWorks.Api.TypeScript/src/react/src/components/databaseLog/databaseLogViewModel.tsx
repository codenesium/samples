import moment from 'moment';

export default class DatabaseLogViewModel {
  databaseLogID: number;
  databaseUser: string;
  reservedEvent: string;
  reservedObject: string;
  postTime: any;
  schema: string;
  tsql: string;
  xmlEvent: string;

  constructor() {
    this.databaseLogID = 0;
    this.databaseUser = '';
    this.reservedEvent = '';
    this.reservedObject = '';
    this.postTime = undefined;
    this.schema = '';
    this.tsql = '';
    this.xmlEvent = '';
  }

  setProperties(
    databaseLogID: number,
    databaseUser: string,
    reservedEvent: string,
    reservedObject: string,
    postTime: any,
    schema: string,
    tsql: string,
    xmlEvent: string
  ): void {
    this.databaseLogID = databaseLogID;
    this.databaseUser = databaseUser;
    this.reservedEvent = reservedEvent;
    this.reservedObject = reservedObject;
    this.postTime = moment(postTime, 'YYYY-MM-DD');
    this.schema = schema;
    this.tsql = tsql;
    this.xmlEvent = xmlEvent;
  }

  toDisplay(): string {
    return String(this.databaseLogID);
  }
}


/*<Codenesium>
    <Hash>eaffc961123d81a9bf5b6e5419f5449e</Hash>
</Codenesium>*/