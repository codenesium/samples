import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ProductDescriptionMapper from './productDescriptionMapper';
import ProductDescriptionViewModel from './productDescriptionViewModel';

interface Props {
	history:any;
    model?:ProductDescriptionViewModel
}

const ProductDescriptionDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.ProductDescriptions + '/edit/' + model.model!.productDescriptionID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="description" className={"col-sm-2 col-form-label"}>Description</label>
							<div className="col-sm-12">
								{String(model.model!.description)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="modifiedDate" className={"col-sm-2 col-form-label"}>ModifiedDate</label>
							<div className="col-sm-12">
								{String(model.model!.modifiedDate)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="productDescriptionID" className={"col-sm-2 col-form-label"}>ProductDescriptionID</label>
							<div className="col-sm-12">
								{String(model.model!.productDescriptionID)}
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
     productDescriptionID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface ProductDescriptionDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface ProductDescriptionDetailComponentState
  {
      model?:ProductDescriptionViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class ProductDescriptionDetailComponent extends React.Component<ProductDescriptionDetailComponentProps, ProductDescriptionDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.ProductDescriptions + '/' + this.props.match.params.productDescriptionID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.ProductDescriptionClientResponseModel;
            
			let mapper = new ProductDescriptionMapper();

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
            return (<ProductDescriptionDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>8d3532a85f2a6b1d90839ad514bbe0ac</Hash>
</Codenesium>*/