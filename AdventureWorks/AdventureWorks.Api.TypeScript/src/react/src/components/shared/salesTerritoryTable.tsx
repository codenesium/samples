import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SalesTerritoryMapper from '../salesTerritory/salesTerritoryMapper';
import SalesTerritoryViewModel from '../salesTerritory/salesTerritoryViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface SalesTerritoryTableComponentProps {
  territoryID:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface SalesTerritoryTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<SalesTerritoryViewModel>;
}

export class  SalesTerritoryTableComponent extends React.Component<
SalesTerritoryTableComponentProps,
SalesTerritoryTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: SalesTerritoryViewModel) {
  this.props.history.push(ClientRoutes.SalesTerritories + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: SalesTerritoryViewModel) {
   this.props.history.push(ClientRoutes.SalesTerritories + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.SalesTerritoryClientResponseModel>;

          console.log(response);

          let mapper = new SalesTerritoryMapper();
          
          let salesTerritories:Array<SalesTerritoryViewModel> = [];

          response.forEach(x =>
          {
              salesTerritories.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: salesTerritories,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'SalesTerritories',
                    columns: [
					  {
                      Header: 'CostLastYear',
                      accessor: 'costLastYear',
                      Cell: (props) => {
                      return <span>{String(props.original.costLastYear)}</span>;
                      }           
                    },  {
                      Header: 'CostYTD',
                      accessor: 'costYTD',
                      Cell: (props) => {
                      return <span>{String(props.original.costYTD)}</span>;
                      }           
                    },  {
                      Header: 'CountryRegionCode',
                      accessor: 'countryRegionCode',
                      Cell: (props) => {
                      return <span>{String(props.original.countryRegionCode)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'SalesLastYear',
                      accessor: 'salesLastYear',
                      Cell: (props) => {
                      return <span>{String(props.original.salesLastYear)}</span>;
                      }           
                    },  {
                      Header: 'SalesYTD',
                      accessor: 'salesYTD',
                      Cell: (props) => {
                      return <span>{String(props.original.salesYTD)}</span>;
                      }           
                    },  {
                      Header: 'TerritoryID',
                      accessor: 'territoryID',
                      Cell: (props) => {
                      return <span>{String(props.original.territoryID)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SalesTerritoryViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as SalesTerritoryViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>da4c923094dd4234bc2b50dbbb1c6a17</Hash>
</Codenesium>*/