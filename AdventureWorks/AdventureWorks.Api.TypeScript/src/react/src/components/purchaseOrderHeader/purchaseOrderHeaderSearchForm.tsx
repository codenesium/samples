import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import PurchaseOrderHeaderMapper from './purchaseOrderHeaderMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import PurchaseOrderHeaderViewModel from './purchaseOrderHeaderViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface PurchaseOrderHeaderSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface PurchaseOrderHeaderSearchComponentState
{
    records:Array<PurchaseOrderHeaderViewModel>;
    filteredRecords:Array<PurchaseOrderHeaderViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class PurchaseOrderHeaderSearchComponent extends React.Component<PurchaseOrderHeaderSearchComponentProps, PurchaseOrderHeaderSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<PurchaseOrderHeaderViewModel>(), filteredRecords:new Array<PurchaseOrderHeaderViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:PurchaseOrderHeaderViewModel) {
         this.props.history.push(ClientRoutes.PurchaseOrderHeaders + '/edit/' + row.purchaseOrderID);
    }

    handleDetailClick(e:any, row:PurchaseOrderHeaderViewModel) {
         this.props.history.push(ClientRoutes.PurchaseOrderHeaders + '/' + row.purchaseOrderID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.PurchaseOrderHeaders + '/create');
    }

    handleDeleteClick(e:any, row:Api.PurchaseOrderHeaderClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.PurchaseOrderHeaders + '/' + row.purchaseOrderID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.PurchaseOrderHeaders + '?limit=100';

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
		    let response = resp.data as Array<Api.PurchaseOrderHeaderClientResponseModel>;
		    let viewModels : Array<PurchaseOrderHeaderViewModel> = [];
			let mapper = new PurchaseOrderHeaderMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<PurchaseOrderHeaderViewModel>(), filteredRecords:new Array<PurchaseOrderHeaderViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'PurchaseOrderHeaders',
                    columns: [
					  {
                      Header: 'EmployeeID',
                      accessor: 'employeeID',
                      Cell: (props) => {
                      return <span>{String(props.original.employeeID)}</span>;
                      }           
                    },  {
                      Header: 'Freight',
                      accessor: 'freight',
                      Cell: (props) => {
                      return <span>{String(props.original.freight)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'OrderDate',
                      accessor: 'orderDate',
                      Cell: (props) => {
                      return <span>{String(props.original.orderDate)}</span>;
                      }           
                    },  {
                      Header: 'PurchaseOrderID',
                      accessor: 'purchaseOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.purchaseOrderID)}</span>;
                      }           
                    },  {
                      Header: 'RevisionNumber',
                      accessor: 'revisionNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.revisionNumber)}</span>;
                      }           
                    },  {
                      Header: 'ShipDate',
                      accessor: 'shipDate',
                      Cell: (props) => {
                      return <span>{String(props.original.shipDate)}</span>;
                      }           
                    },  {
                      Header: 'ShipMethodID',
                      accessor: 'shipMethodID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.ShipMethods + '/' + props.original.shipMethodID); }}>
                          {String(
                            props.original.shipMethodIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Status',
                      accessor: 'status',
                      Cell: (props) => {
                      return <span>{String(props.original.status)}</span>;
                      }           
                    },  {
                      Header: 'SubTotal',
                      accessor: 'subTotal',
                      Cell: (props) => {
                      return <span>{String(props.original.subTotal)}</span>;
                      }           
                    },  {
                      Header: 'TaxAmt',
                      accessor: 'taxAmt',
                      Cell: (props) => {
                      return <span>{String(props.original.taxAmt)}</span>;
                      }           
                    },  {
                      Header: 'TotalDue',
                      accessor: 'totalDue',
                      Cell: (props) => {
                      return <span>{String(props.original.totalDue)}</span>;
                      }           
                    },  {
                      Header: 'VendorID',
                      accessor: 'vendorID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Vendors + '/' + props.original.vendorID); }}>
                          {String(
                            props.original.vendorIDNavigation.toDisplay()
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
                              row.original as PurchaseOrderHeaderViewModel
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
                              row.original as PurchaseOrderHeaderViewModel
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
                              row.original as PurchaseOrderHeaderViewModel
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

export const WrappedPurchaseOrderHeaderSearchComponent = Form.create({ name: 'PurchaseOrderHeader Search' })(PurchaseOrderHeaderSearchComponent);

/*<Codenesium>
    <Hash>df9894da2be19f52bd9d26cd6f5de20b</Hash>
</Codenesium>*/