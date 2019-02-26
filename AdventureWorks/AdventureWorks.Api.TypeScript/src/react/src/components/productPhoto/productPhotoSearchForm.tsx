import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import ProductPhotoMapper from './productPhotoMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import ProductPhotoViewModel from './productPhotoViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface ProductPhotoSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
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

    handleEditClick(e:any, row:ProductPhotoViewModel) {
         this.props.history.push(ClientRoutes.ProductPhotoes + '/edit/' + row.productPhotoID);
    }

    handleDetailClick(e:any, row:ProductPhotoViewModel) {
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
		   this.setState({records:new Array<ProductPhotoViewModel>(), filteredRecords:new Array<ProductPhotoViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
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
                    Header: 'ProductPhotoes',
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
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as ProductPhotoViewModel
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
                              row.original as ProductPhotoViewModel
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
                              row.original as ProductPhotoViewModel
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

export const WrappedProductPhotoSearchComponent = Form.create({ name: 'ProductPhoto Search' })(ProductPhotoSearchComponent);

/*<Codenesium>
    <Hash>1fd7a94000ad07062489b0b15f781eda</Hash>
</Codenesium>*/