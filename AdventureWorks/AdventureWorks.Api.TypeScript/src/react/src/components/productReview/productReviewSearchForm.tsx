import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductReviewMapper from './productReviewMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import ProductReviewViewModel from './productReviewViewModel';
import "react-table/react-table.css";

interface ProductReviewSearchComponentProps
{
    history:any;
}

interface ProductReviewSearchComponentState
{
    records:Array<ProductReviewViewModel>;
    filteredRecords:Array<ProductReviewViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class ProductReviewSearchComponent extends React.Component<ProductReviewSearchComponentProps, ProductReviewSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<ProductReviewViewModel>(), filteredRecords:new Array<ProductReviewViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.ProductReviewClientResponseModel) {
         this.props.history.push(ClientRoutes.ProductReviews + '/edit/' + row.productReviewID);
    }

    handleDetailClick(e:any, row:Api.ProductReviewClientResponseModel) {
         this.props.history.push(ClientRoutes.ProductReviews + '/' + row.productReviewID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.ProductReviews + '/create');
    }

    handleDeleteClick(e:any, row:Api.ProductReviewClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.ProductReviews + '/' + row.productReviewID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.ProductReviews + '?limit=100';

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
		    let response = resp.data as Array<Api.ProductReviewClientResponseModel>;
		    let viewModels : Array<ProductReviewViewModel> = [];
			let mapper = new ProductReviewMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<ProductReviewViewModel>(),filteredRecords:new Array<ProductReviewViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <LoadingForm />;
        } 
		else if(this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if(this.state.deleteSubmitted){
                if(this.state.deleteSuccess){
                    errorResponse =<div className="alert alert-success">{this.state.deleteResponse}</div>   
                }
                else {
                    errorResponse = <div className="alert alert-danger">{this.state.deleteResponse}</div>   
                }
            }
            return (
            <div>
                { 
                    errorResponse
                }
            <form>
                <div className="form-group row">
                    <div className="col-sm-4">
                    </div>
                    <div className="col-sm-4">
                        <input name="search" className="form-control" placeholder={"Search"} value={this.state.searchValue} onChange={e => this.handleSearchChanged(e)}/>
                    </div>
                    <div className="col-sm-4">
                        <button className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button" onClick={e => this.handleCreateClick(e)}><i className="fas fa-plus"></i></button>
                    </div>
                </div>
            </form>
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'ProductReview',
                    columns: [
					  {
                      Header: 'Comments',
                      accessor: 'comment',
                      Cell: (props) => {
                      return <span>{String(props.original.comment)}</span>;
                      }           
                    },  {
                      Header: 'EmailAddress',
                      accessor: 'emailAddress',
                      Cell: (props) => {
                      return <span>{String(props.original.emailAddress)}</span>;
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
                      return <span>{String(props.original.productID)}</span>;
                      }           
                    },  {
                      Header: 'ProductReviewID',
                      accessor: 'productReviewID',
                      Cell: (props) => {
                      return <span>{String(props.original.productReviewID)}</span>;
                      }           
                    },  {
                      Header: 'Rating',
                      accessor: 'rating',
                      Cell: (props) => {
                      return <span>{String(props.original.rating)}</span>;
                      }           
                    },  {
                      Header: 'ReviewDate',
                      accessor: 'reviewDate',
                      Cell: (props) => {
                      return <span>{String(props.original.reviewDate)}</span>;
                      }           
                    },  {
                      Header: 'ReviewerName',
                      accessor: 'reviewerName',
                      Cell: (props) => {
                      return <span>{String(props.original.reviewerName)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.ProductReviewClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.ProductReviewClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.ProductReviewClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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

/*<Codenesium>
    <Hash>89388dee2bbaa56ef430c92d624a06eb</Hash>
</Codenesium>*/