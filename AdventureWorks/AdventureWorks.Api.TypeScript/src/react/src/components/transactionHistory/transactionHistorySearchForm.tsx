import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import TransactionHistoryMapper from './transactionHistoryMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import TransactionHistoryViewModel from './transactionHistoryViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface TransactionHistorySearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface TransactionHistorySearchComponentState
{
    records:Array<TransactionHistoryViewModel>;
    filteredRecords:Array<TransactionHistoryViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class TransactionHistorySearchComponent extends React.Component<TransactionHistorySearchComponentProps, TransactionHistorySearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<TransactionHistoryViewModel>(), filteredRecords:new Array<TransactionHistoryViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:TransactionHistoryViewModel) {
         this.props.history.push(ClientRoutes.TransactionHistories + '/edit/' + row.transactionID);
    }

    handleDetailClick(e:any, row:TransactionHistoryViewModel) {
         this.props.history.push(ClientRoutes.TransactionHistories + '/' + row.transactionID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.TransactionHistories + '/create');
    }

    handleDeleteClick(e:any, row:Api.TransactionHistoryClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.TransactionHistories + '/' + row.transactionID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.TransactionHistories + '?limit=100';

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
		    let response = resp.data as Array<Api.TransactionHistoryClientResponseModel>;
		    let viewModels : Array<TransactionHistoryViewModel> = [];
			let mapper = new TransactionHistoryMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<TransactionHistoryViewModel>(), filteredRecords:new Array<TransactionHistoryViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'TransactionHistories',
                    columns: [
					  {
                      Header: 'ActualCost',
                      accessor: 'actualCost',
                      Cell: (props) => {
                      return <span>{String(props.original.actualCost)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'ProductID',
                      accessor: 'productID',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Products + '/' + props.original.productID); }}>
                          {String(
                            props.original.productIDNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Quantity',
                      accessor: 'quantity',
                      Cell: (props) => {
                      return <span>{String(props.original.quantity)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderID',
                      accessor: 'referenceOrderID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderID)}</span>;
                      }           
                    },  {
                      Header: 'ReferenceOrderLineID',
                      accessor: 'referenceOrderLineID',
                      Cell: (props) => {
                      return <span>{String(props.original.referenceOrderLineID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionDate',
                      accessor: 'transactionDate',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionDate)}</span>;
                      }           
                    },  {
                      Header: 'TransactionID',
                      accessor: 'transactionID',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionID)}</span>;
                      }           
                    },  {
                      Header: 'TransactionType',
                      accessor: 'transactionType',
                      Cell: (props) => {
                      return <span>{String(props.original.transactionType)}</span>;
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
                              row.original as TransactionHistoryViewModel
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
                              row.original as TransactionHistoryViewModel
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
                              row.original as TransactionHistoryViewModel
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

export const WrappedTransactionHistorySearchComponent = Form.create({ name: 'TransactionHistory Search' })(TransactionHistorySearchComponent);

/*<Codenesium>
    <Hash>8853ca1cf310a7937a7530a16211373d</Hash>
</Codenesium>*/