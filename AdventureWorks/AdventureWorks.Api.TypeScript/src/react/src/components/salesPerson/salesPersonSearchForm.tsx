import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesPersonMapper from './salesPersonMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import SalesPersonViewModel from './salesPersonViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesPersonSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface SalesPersonSearchComponentState
{
    records:Array<SalesPersonViewModel>;
    filteredRecords:Array<SalesPersonViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class SalesPersonSearchComponent extends React.Component<SalesPersonSearchComponentProps, SalesPersonSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<SalesPersonViewModel>(), filteredRecords:new Array<SalesPersonViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:SalesPersonViewModel) {
         this.props.history.push(ClientRoutes.SalesPersons + '/edit/' + row.businessEntityID);
    }

    handleDetailClick(e:any, row:SalesPersonViewModel) {
         this.props.history.push(ClientRoutes.SalesPersons + '/' + row.businessEntityID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.SalesPersons + '/create');
    }

    handleDeleteClick(e:any, row:Api.SalesPersonClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.SalesPersons + '/' + row.businessEntityID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state, deleteResponse:'Record deleted', deleteSuccess:true, deleteSubmitted:true});
            this.loadRecords(this.state.searchValue);
        }, error => {
            console.log(error);
            this.setState({...this.state, deleteResponse:'Error deleting record', deleteSuccess:false, deleteSubmitted:true});
        })
    }

   handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
		this.loadRecords(e.currentTarget.value);
   }
   
   loadRecords(query:string = '') {
	   this.setState({...this.state, searchValue:query});
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.SalesPersons + '?limit=100';

	   if(query)
	   {
		   searchEndpoint += '&query=' +  query;
	   }

	   axios.get(searchEndpoint,
	   {
		   headers: {
			   'Content-Type': 'application/json',
		   }
	   })
	   .then(resp => {
		    let response = resp.data as Array<Api.SalesPersonClientResponseModel>;
		    let viewModels : Array<SalesPersonViewModel> = [];
			let mapper = new SalesPersonMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<SalesPersonViewModel>(), filteredRecords:new Array<SalesPersonViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <Spin size="large" />;
        } 
		else if(this.state.errorOccurred) {
            return <Alert message={this.state.errorMessage} type="error" />
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if (this.state.deleteSubmitted) {
				if (this.state.deleteSuccess) {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="success" style={{marginBottom:"25px"}} />
				  );
				} else {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="error" style={{marginBottom:"25px"}} />
				  );
				}
			}
            
			return (
            <div>
            {errorResponse}
            <Row>
				<Col span={8}></Col>
				<Col span={8}>   
				   <Input 
					placeholder={"Search"} 
					id={"search"} 
					onChange={(e:any) => {
					  this.handleSearchChanged(e)
				   }}/>
				</Col>
				<Col span={8}>  
				  <Button 
				  style={{'float':'right'}}
				  type="primary" 
				  onClick={(e:any) => {
                        this.handleCreateClick(e)
						}}
				  >
				  +
				  </Button>
				</Col>
			</Row>
			<br />
			<br />
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'SalesPersons',
                    columns: [
					  {
                      Header: 'Bonus',
                      accessor: 'bonus',
                      Cell: (props) => {
                      return <span>{String(props.original.bonus)}</span>;
                      }           
                    },  {
                      Header: 'BusinessEntityID',
                      accessor: 'businessEntityID',
                      Cell: (props) => {
                      return <span>{String(props.original.businessEntityID)}</span>;
                      }           
                    },  {
                      Header: 'CommissionPct',
                      accessor: 'commissionPct',
                      Cell: (props) => {
                      return <span>{String(props.original.commissionPct)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
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
                      Header: 'SalesQuota',
                      accessor: 'salesQuota',
                      Cell: (props) => {
                      return <span>{String(props.original.salesQuota)}</span>;
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
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.SalesTerritories + '/' + props.original.territoryID); }}>
                          {String(
                            props.original.territoryIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as SalesPersonViewModel
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
                              row.original as SalesPersonViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger" 
                          onClick={(e:any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as SalesPersonViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>

                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
		else {
		  return null;
		}
    }
}

export const WrappedSalesPersonSearchComponent = Form.create({ name: 'SalesPerson Search' })(SalesPersonSearchComponent);

/*<Codenesium>
    <Hash>7b34487bab47d5dbbc978cfd82e78970</Hash>
</Codenesium>*/