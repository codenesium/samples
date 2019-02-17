import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ProductModelMapper from './productModelMapper';
import ProductModelViewModel from './productModelViewModel';

interface Props {
	history:any;
    model?:ProductModelViewModel
}

const ProductModelDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.ProductModels + '/edit/' + model.model!.productModelID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="catalogDescription" className={"col-sm-2 col-form-label"}>CatalogDescription</label>
							<div className="col-sm-12">
								{String(model.model!.catalogDescription)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="instruction" className={"col-sm-2 col-form-label"}>Instructions</label>
							<div className="col-sm-12">
								{String(model.model!.instruction)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="name" className={"col-sm-2 col-form-label"}>Name</label>
							<div className="col-sm-12">
								{String(model.model!.name)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="productModelID" className={"col-sm-2 col-form-label"}>ProductModelID</label>
							<div className="col-sm-12">
								{String(model.model!.productModelID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="rowguid" className={"col-sm-2 col-form-label"}>Rowguid</label>
							<div className="col-sm-12">
								{String(model.model!.rowguid)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     productModelID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface ProductModelDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface ProductModelDetailComponentState
  {
      model?:ProductModelViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class ProductModelDetailComponent extends React.Component<ProductModelDetailComponentProps, ProductModelDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ProductModels + '/' + this.props.match.params.productModelID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ProductModelClientResponseModel;
            
			let mapper = new ProductModelMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
		else if (this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<ProductModelDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>9f7876c094999e0098f0d2486be848fc</Hash>
</Codenesium>*/