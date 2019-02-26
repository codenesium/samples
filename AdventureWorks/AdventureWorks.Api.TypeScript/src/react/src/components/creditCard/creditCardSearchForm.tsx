import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import CreditCardMapper from './creditCardMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import CreditCardViewModel from './creditCardViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CreditCardSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface CreditCardSearchComponentState
{
    records:Array<CreditCardViewModel>;
    filteredRecords:Array<CreditCardViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class CreditCardSearchComponent extends React.Component<CreditCardSearchComponentProps, CreditCardSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<CreditCardViewModel>(), filteredRecords:new Array<CreditCardViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:CreditCardViewModel) {
         this.props.history.push(ClientRoutes.CreditCards + '/edit/' + row.creditCardID);
    }

    handleDetailClick(e:any, row:CreditCardViewModel) {
         this.props.history.push(ClientRoutes.CreditCards + '/' + row.creditCardID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.CreditCards + '/create');
    }

    handleDeleteClick(e:any, row:Api.CreditCardClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.CreditCards + '/' + row.creditCardID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.CreditCards + '?limit=100';

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
		    let response = resp.data as Array<Api.CreditCardClientResponseModel>;
		    let viewModels : Array<CreditCardViewModel> = [];
			let mapper = new CreditCardMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<CreditCardViewModel>(), filteredRecords:new Array<CreditCardViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'CreditCards',
                    columns: [
					  {
                      Header: 'CardNumber',
                      accessor: 'cardNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.cardNumber)}</span>;
                      }           
                    },  {
                      Header: 'CardType',
                      accessor: 'cardType',
                      Cell: (props) => {
                      return <span>{String(props.original.cardType)}</span>;
                      }           
                    },  {
                      Header: 'CreditCardID',
                      accessor: 'creditCardID',
                      Cell: (props) => {
                      return <span>{String(props.original.creditCardID)}</span>;
                      }           
                    },  {
                      Header: 'ExpMonth',
                      accessor: 'expMonth',
                      Cell: (props) => {
                      return <span>{String(props.original.expMonth)}</span>;
                      }           
                    },  {
                      Header: 'ExpYear',
                      accessor: 'expYear',
                      Cell: (props) => {
                      return <span>{String(props.original.expYear)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
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
                              row.original as CreditCardViewModel
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
                              row.original as CreditCardViewModel
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
                              row.original as CreditCardViewModel
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

export const WrappedCreditCardSearchComponent = Form.create({ name: 'CreditCard Search' })(CreditCardSearchComponent);

/*<Codenesium>
    <Hash>50d1dd4c3859f86707bc9aff68eb444f</Hash>
</Codenesium>*/