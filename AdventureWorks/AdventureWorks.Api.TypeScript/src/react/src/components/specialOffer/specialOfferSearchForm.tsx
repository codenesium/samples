import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import SpecialOfferMapper from './specialOfferMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import SpecialOfferViewModel from './specialOfferViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface SpecialOfferSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface SpecialOfferSearchComponentState
{
    records:Array<SpecialOfferViewModel>;
    filteredRecords:Array<SpecialOfferViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class SpecialOfferSearchComponent extends React.Component<SpecialOfferSearchComponentProps, SpecialOfferSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<SpecialOfferViewModel>(), filteredRecords:new Array<SpecialOfferViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:SpecialOfferViewModel) {
         this.props.history.push(ClientRoutes.SpecialOffers + '/edit/' + row.specialOfferID);
    }

    handleDetailClick(e:any, row:SpecialOfferViewModel) {
         this.props.history.push(ClientRoutes.SpecialOffers + '/' + row.specialOfferID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.SpecialOffers + '/create');
    }

    handleDeleteClick(e:any, row:Api.SpecialOfferClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.SpecialOffers + '/' + row.specialOfferID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.SpecialOffers + '?limit=100';

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
		    let response = resp.data as Array<Api.SpecialOfferClientResponseModel>;
		    let viewModels : Array<SpecialOfferViewModel> = [];
			let mapper = new SpecialOfferMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<SpecialOfferViewModel>(), filteredRecords:new Array<SpecialOfferViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'SpecialOffers',
                    columns: [
					  {
                      Header: 'Category',
                      accessor: 'category',
                      Cell: (props) => {
                      return <span>{String(props.original.category)}</span>;
                      }           
                    },  {
                      Header: 'Description',
                      accessor: 'description',
                      Cell: (props) => {
                      return <span>{String(props.original.description)}</span>;
                      }           
                    },  {
                      Header: 'DiscountPct',
                      accessor: 'discountPct',
                      Cell: (props) => {
                      return <span>{String(props.original.discountPct)}</span>;
                      }           
                    },  {
                      Header: 'EndDate',
                      accessor: 'endDate',
                      Cell: (props) => {
                      return <span>{String(props.original.endDate)}</span>;
                      }           
                    },  {
                      Header: 'MaxQty',
                      accessor: 'maxQty',
                      Cell: (props) => {
                      return <span>{String(props.original.maxQty)}</span>;
                      }           
                    },  {
                      Header: 'MinQty',
                      accessor: 'minQty',
                      Cell: (props) => {
                      return <span>{String(props.original.minQty)}</span>;
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
                      Header: 'SpecialOfferID',
                      accessor: 'specialOfferID',
                      Cell: (props) => {
                      return <span>{String(props.original.specialOfferID)}</span>;
                      }           
                    },  {
                      Header: 'StartDate',
                      accessor: 'startDate',
                      Cell: (props) => {
                      return <span>{String(props.original.startDate)}</span>;
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
                              row.original as SpecialOfferViewModel
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
                              row.original as SpecialOfferViewModel
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
                              row.original as SpecialOfferViewModel
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

export const WrappedSpecialOfferSearchComponent = Form.create({ name: 'SpecialOffer Search' })(SpecialOfferSearchComponent);

/*<Codenesium>
    <Hash>5b7e28caedd932f9cc8b76787c99bc26</Hash>
</Codenesium>*/