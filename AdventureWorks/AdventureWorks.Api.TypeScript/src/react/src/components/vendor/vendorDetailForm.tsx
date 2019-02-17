import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import VendorMapper from './vendorMapper';
import VendorViewModel from './vendorViewModel';

interface Props {
	history:any;
    model?:VendorViewModel
}

const VendorDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Vendors + '/edit/' + model.model!.businessEntityID)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="accountNumber" className={"col-sm-2 col-form-label"}>AccountNumber</label>
							<div className="col-sm-12">
								{String(model.model!.accountNumber)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="activeFlag" className={"col-sm-2 col-form-label"}>ActiveFlag</label>
							<div className="col-sm-12">
								{String(model.model!.activeFlag)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="businessEntityID" className={"col-sm-2 col-form-label"}>BusinessEntityID</label>
							<div className="col-sm-12">
								{String(model.model!.businessEntityID)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="creditRating" className={"col-sm-2 col-form-label"}>CreditRating</label>
							<div className="col-sm-12">
								{String(model.model!.creditRating)}
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
							<label htmlFor="preferredVendorStatu" className={"col-sm-2 col-form-label"}>PreferredVendorStatus</label>
							<div className="col-sm-12">
								{String(model.model!.preferredVendorStatu)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="purchasingWebServiceURL" className={"col-sm-2 col-form-label"}>PurchasingWebServiceURL</label>
							<div className="col-sm-12">
								{String(model.model!.purchasingWebServiceURL)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     businessEntityID:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface VendorDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface VendorDetailComponentState
  {
      model?:VendorViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class VendorDetailComponent extends React.Component<VendorDetailComponentProps, VendorDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Vendors + '/' + this.props.match.params.businessEntityID,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.VendorClientResponseModel;
            
			let mapper = new VendorMapper();

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
            return (<VendorDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>e73455a917c8ea4e202aafba7856215d</Hash>
</Codenesium>*/