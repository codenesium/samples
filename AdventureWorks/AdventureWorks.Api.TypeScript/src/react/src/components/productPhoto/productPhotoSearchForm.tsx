import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import ProductPhotoViewModel from './productPhotoViewModel';
import "react-table/react-table.css";

interface ProductPhotoSearchComponentProps
{
    history:any;
}

interface ProductPhotoSearchComponentState
{
    records:Array<ProductPhotoViewModel>;
    filteredRecords:Array<ProductPhotoViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class ProductPhotoSearchComponent extends React.Component<ProductPhotoSearchComponentProps, ProductPhotoSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<ProductPhotoViewModel>(), filteredRecords:new Array<ProductPhotoViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.ProductPhotoClientResponseModel) {
         this.props.history.push(ClientRoutes.ProductPhotoes + '/edit/' + row.productPhotoID);
    }

    handleDetailClick(e:any, row:Api.ProductPhotoClientResponseModel) {
         this.props.history.push(ClientRoutes.ProductPhotoes + '/' + row.productPhotoID);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.ProductPhotoes + '/create');
    }

    handleDeleteClick(e:any, row:Api.ProductPhotoClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.ProductPhotoes + '/' + row.productPhotoID,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.ProductPhotoes + '?limit=100';

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
		    let response = resp.data as Array<Api.ProductPhotoClientResponseModel>;
		    let viewModels : Array<ProductPhotoViewModel> = [];
			let mapper = new ProductPhotoMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<ProductPhotoViewModel>(),filteredRecords:new Array<ProductPhotoViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'ProductPhoto',
                    columns: [
					  {
                      Header: 'LargePhoto',
                      accessor: 'largePhoto',
                      Cell: (props) => {
                      return <span>{String(props.original.largePhoto)}</span>;
                      }           
                    },  {
                      Header: 'LargePhotoFileName',
                      accessor: 'largePhotoFileName',
                      Cell: (props) => {
                      return <span>{String(props.original.largePhotoFileName)}</span>;
                      }           
                    },  {
                      Header: 'ModifiedDate',
                      accessor: 'modifiedDate',
                      Cell: (props) => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                      }           
                    },  {
                      Header: 'ProductPhotoID',
                      accessor: 'productPhotoID',
                      Cell: (props) => {
                      return <span>{String(props.original.productPhotoID)}</span>;
                      }           
                    },  {
                      Header: 'ThumbNailPhoto',
                      accessor: 'thumbNailPhoto',
                      Cell: (props) => {
                      return <span>{String(props.original.thumbNailPhoto)}</span>;
                      }           
                    },  {
                      Header: 'ThumbnailPhotoFileName',
                      accessor: 'thumbnailPhotoFileName',
                      Cell: (props) => {
                      return <span>{String(props.original.thumbnailPhotoFileName)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.ProductPhotoClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.ProductPhotoClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.ProductPhotoClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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
    <Hash>f21df2d6c579bf4abbdd8ce5290f5182</Hash>
</Codenesium>*/