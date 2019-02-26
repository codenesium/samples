import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SalesOrderHeaderMapper from './salesOrderHeaderMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import SalesOrderHeaderViewModel from './salesOrderHeaderViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SalesOrderHeaderSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface SalesOrderHeaderSearchComponentState
{
    records:Array<SalesOrderHeaderViewModel>;
    filteredRecords:Array<SalesOrderHeaderViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class SalesOrderHeaderSearchComponent extends React.Component<SalesOrderHeaderSearchComponentProps, SalesOrderHeaderSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<SalesOrderHeaderViewModel>(), filteredRecords:new Array<SalesOrderHeaderViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:SalesOrderHeaderViewModel) {
         this.props.history.push(ClientRoutes.SalesOrderHeaders + '/edit/' + row.salesOrderID);
    }

    handleDetailClick(e:any, row:SalesOrderHeaderViewModel) {
         this.props.history.push(ClientRoutes.SalesOrderHeaders + '/' + row.salesOrderID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.SalesOrderHeaders + '/create');
    }

    handleDeleteClick(e:any, row:Api.SalesOrderHeaderClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders + '/' + row.salesOrderID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.SalesOrderHeaders + '?limit=100';

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
		    let response = resp.data as Array<Api.SalesOrderHeaderClientResponseModel>;
		    let viewModels : Array<SalesOrderHeaderViewModel> = [];
			let mapper = new SalesOrderHeaderMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<SalesOrderHeaderViewModel>(), filteredRecords:new Array<SalesOrderHeaderViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'SalesOrderHeaders',
                    columns: [
					  {
                      Header: 'AccountNumber',
                      accessor: 'accountNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.accountNumber)}</span>;
                      }           
                    },  {
                      Header: 'BillToAddressID',
                      accessor: 'billToAddressID',
                      Cell: (props) => {
                      return <span>{String(props.original.billToAddressID)}</span>;
                      }           
                    },  {
                      Header: 'Comment',
                      accessor: 'comment',
                      Cell: (props) => {
                      return <span>{String(props.original.comment)}</span>;
                      }           
                    },  {
                      Header: 'CreditCardApprovalCode',
                      accessor: 'creditCardApprovalCode',
                      Cell: (props) => {
                      return <span>{String(props.original.creditCardApprovalCode)}</span>;
                      }           
                    },  {
                      Header: 'CreditCardID',
                      accessor: 'creditCardID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.CreditCards + '/' + props.original.creditCardID); }}>
                          {String(
                            props.original.creditCardIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'CurrencyRateID',
                      accessor: 'currencyRateID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.CurrencyRates + '/' + props.original.currencyRateID); }}>
                          {String(
                            props.original.currencyRateIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'CustomerID',
                      accessor: 'customerID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Customers + '/' + props.original.customerID); }}>
                          {String(
                            props.original.customerIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DueDate',
                      accessor: 'dueDate',
                      Cell: (props) => {
                      return <span>{String(props.original.dueDate)}</span>;
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
                      Header: 'OnlineOrderFlag',
                      accessor: 'onlineOrderFlag',
                      Cell: (props) => {
                      return <span>{String(props.original.onlineOrderFlag)}</span>;
                      }           
                    },  {
                      Header: 'OrderDate',
                      accessor: 'orderDate',
                      Cell: (props) => {
                      return <span>{String(props.original.orderDate)}</span>;
                      }           
                    },  {
                      Header: 'PurchaseOrderNumber',
                      accessor: 'purchaseOrderNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.purchaseOrderNumber)}</span>;
                      }           
                    },  {
                      Header: 'RevisionNumber',
                      accessor: 'revisionNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.revisionNumber)}</span>;
                      }           
                    },  {
                      Header: 'Rowguid',
                      accessor: 'rowguid',
                      Cell: (props) => {
                      return <span>{String(props.original.rowguid)}</span>;
                      }           
                    },  {
                      Header: 'SalesOrderID',
                      accessor: 'salesOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.salesOrderID)}</span>;
                      }           
                    },  {
                      Header: 'SalesOrderNumber',
                      accessor: 'salesOrderNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.salesOrderNumber)}</span>;
                      }           
                    },  {
                      Header: 'SalesPersonID',
                      accessor: 'salesPersonID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.SalesPersons + '/' + props.original.salesPersonID); }}>
                          {String(
                            props.original.salesPersonIDNavigation.toDisplay()
                          )}
                        </a>
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
                      return <span>{String(props.original.shipMethodID)}</span>;
                      }           
                    },  {
                      Header: 'ShipToAddressID',
                      accessor: 'shipToAddressID',
                      Cell: (props) => {
                      return <span>{String(props.original.shipToAddressID)}</span>;
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
                      Header: 'TerritoryID',
                      accessor: 'territoryID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.SalesTerritories + '/' + props.original.territoryID); }}>
                          {String(
                            props.original.territoryIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'TotalDue',
                      accessor: 'totalDue',
                      Cell: (props) => {
                      return <span>{String(props.original.totalDue)}</span>;
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
                              row.original as SalesOrderHeaderViewModel
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
                              row.original as SalesOrderHeaderViewModel
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
                              row.original as SalesOrderHeaderViewModel
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

export const WrappedSalesOrderHeaderSearchComponent = Form.create({ name: 'SalesOrderHeader Search' })(SalesOrderHeaderSearchComponent);

/*<Codenesium>
    <Hash>379b9acf33b3239fab020d7468600e4b</Hash>
</Codenesium>*/